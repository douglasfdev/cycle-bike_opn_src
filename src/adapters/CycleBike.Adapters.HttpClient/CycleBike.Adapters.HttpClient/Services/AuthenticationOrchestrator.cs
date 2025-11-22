using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CycleBike.Adapters.HttpClient.Enums;
using CycleBike.Adapters.HttpClient.Interfaces;
using CycleBike.Adapters.HttpClient.Models;

namespace CycleBike.Adapters.HttpClient.Services;

public class AuthenticationOrchestrator(IHttpClientFactory httpClientFactory) : IAuthenticationOrchestrator
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly Dictionary<string, (string Token, DateTime ExpiresAt)> _tokenCache = new();

    public async Task ApplyAuthenticationAsync(HttpRequestMessage request, AuthenticationConfig config,
        CancellationToken cancellationToken = default)
    {
        switch (config.Type)
        {
            case AuthenticationType.None:
                break;
                
            case AuthenticationType.Basic:
                ApplyBasicAuth(request, config);
                break;
                
            case AuthenticationType.Bearer:
                ApplyBearerAuth(request, config);
                break;
                
            case AuthenticationType.JwtBearer:
                ApplyJwtBearerAuth(request, config);
                break;
                
            case AuthenticationType.ApiKey:
                ApplyApiKeyAuth(request, config);
                break;
                
            case AuthenticationType.OAuth2:
                await ApplyOAuth2Async(request, config, cancellationToken);
                break;
                
            default:
                throw new NotSupportedException($"Authentication type {config.Type} is not supported.");
        }
    }
    
    private void ApplyBasicAuth(HttpRequestMessage request, AuthenticationConfig config)
    {
        if (string.IsNullOrEmpty(config.Username) || string.IsNullOrEmpty(config.Password))
            throw new ArgumentException("Username and Password are required for Basic authentication.");

        var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{config.Username}:{config.Password}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
    }

    private void ApplyBearerAuth(HttpRequestMessage request, AuthenticationConfig config)
    {
        if (string.IsNullOrEmpty(config.Token))
            throw new ArgumentException("Token is required for Bearer authentication.");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", config.Token);
    }

    private void ApplyJwtBearerAuth(HttpRequestMessage request, AuthenticationConfig config)
    {
        if (string.IsNullOrEmpty(config.Token))
            throw new ArgumentException("Token is required for JWT Bearer authentication.");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", config.Token);
    }

    private void ApplyApiKeyAuth(HttpRequestMessage request, AuthenticationConfig config)
    {
        if (string.IsNullOrEmpty(config.ApiKeyName) || string.IsNullOrEmpty(config.ApiKeyValue))
            throw new ArgumentException("ApiKeyName and ApiKeyValue are required for API Key authentication.");

        if (config.ApiKeyLocation == ApiKeyLocation.Header)
        {
            request.Headers.Add(config.ApiKeyName, config.ApiKeyValue);
        }
        else if (config.ApiKeyLocation == ApiKeyLocation.QueryString)
        {
            var uriBuilder = new UriBuilder(request.RequestUri!);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            query[config.ApiKeyName] = config.ApiKeyValue;
            uriBuilder.Query = query.ToString();
            request.RequestUri = uriBuilder.Uri;
        }
    }

    private async Task ApplyOAuth2Async(HttpRequestMessage request, AuthenticationConfig config, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(config.ClientId) || string.IsNullOrEmpty(config.ClientSecret) || string.IsNullOrEmpty(config.TokenEndpoint))
            throw new ArgumentException("ClientId, ClientSecret, and TokenEndpoint are required for OAuth2 authentication.");

        var cacheKey = $"{config.ClientId}:{config.TokenEndpoint}";
        
        // Check cache
        if (_tokenCache.TryGetValue(cacheKey, out var cachedToken) && cachedToken.ExpiresAt > DateTime.UtcNow.AddMinutes(1))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", cachedToken.Token);
            return;
        }

        // Request new token
        var token = await RequestOAuth2TokenAsync(config, cancellationToken);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    private async Task<string> RequestOAuth2TokenAsync(AuthenticationConfig config, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient();
        
        var requestBody = new Dictionary<string, string>
        {
            ["grant_type"] = config.GrantType ?? "client_credentials",
            ["client_id"] = config.ClientId!,
            ["client_secret"] = config.ClientSecret!
        };

        if (!string.IsNullOrEmpty(config.Scope))
            requestBody["scope"] = config.Scope;

        var content = new FormUrlEncodedContent(requestBody);
        var response = await client.PostAsync(config.TokenEndpoint, content, cancellationToken);
        
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var tokenResponse = JsonSerializer.Deserialize<OAuth2TokenResponse>(responseContent);

        if (tokenResponse?.AccessToken == null)
            throw new InvalidOperationException("Failed to retrieve access token from OAuth2 endpoint.");

        // Cache token
        var cacheKey = $"{config.ClientId}:{config.TokenEndpoint}";
        var expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn ?? 3600);
        _tokenCache[cacheKey] = (tokenResponse.AccessToken, expiresAt);

        return tokenResponse.AccessToken;
    }

    private class OAuth2TokenResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
        
        [System.Text.Json.Serialization.JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }
        
        [System.Text.Json.Serialization.JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
    }
}