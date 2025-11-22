using System.Text;
using System.Text.Json;
using System.Web;
using CycleBike.Adapters.HttpClient.Interfaces;
using CycleBike.Adapters.HttpClient.Models;

namespace CycleBike.Adapters.HttpClient.Services;

public class HttpClientAdapter(
    IHttpClientFactory httpClientFactory,
    IAuthenticationOrchestrator authOrchestrator)
    : IHttpClientAdapter
{
    private readonly IHttpClientFactory _httpClientFactory  = httpClientFactory;
    private readonly IAuthenticationOrchestrator _authOrchestrator = authOrchestrator;
    private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    public async Task<HttpResponse<T>> GetAsync<T>(string url, HttpRequestConfig? config = null, CancellationToken cancellationToken = default)
        => await SendRequestAsync<T>(HttpMethod.Get, url, null, config, cancellationToken);

    public async Task<HttpResponse<string>> GetAsync(string url, HttpRequestConfig? config = null, CancellationToken cancellationToken = default)
        => await SendRequestAsync<string>(HttpMethod.Get, url, null, config, cancellationToken);

    public async Task<HttpResponse<T>> PostAsync<T>(string url, object? body = null, HttpRequestConfig? config = null,
        CancellationToken cancellationToken = default)
        => await SendRequestAsync<T>(HttpMethod.Post, url, body, config, cancellationToken);

    public async Task<HttpResponse<T>> PutAsync<T>(string url, object? body = null, HttpRequestConfig? config = null,
        CancellationToken cancellationToken = default)
        => await SendRequestAsync<T>(HttpMethod.Put, url, body, config, cancellationToken);

    public async Task<HttpResponse<T>> DeleteAsync<T>(string url, HttpRequestConfig? config = null, CancellationToken cancellationToken = default)
        => await SendRequestAsync<T>(HttpMethod.Delete, url, null, config, cancellationToken);

    public async Task<HttpResponse<string>> DeleteAsync(string url, HttpRequestConfig? config = null, CancellationToken cancellationToken = default)
        => await SendRequestAsync<string>(HttpMethod.Delete, url, null, config, cancellationToken);

    public async Task<HttpResponse<T>> PatchAsync<T>(string url, object? body = null, HttpRequestConfig? config = null,
        CancellationToken cancellationToken = default)
        => await SendRequestAsync<T>(HttpMethod.Patch, url, body, config, cancellationToken);
    
    private async Task<HttpResponse<T>> SendRequestAsync<T>(HttpMethod method, string url, object? body, HttpRequestConfig? config, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient();
        
        // Apply timeout if specified
        if (config?.Timeout.HasValue == true)
        {
            client.Timeout = config.Timeout.Value;
        }

        // Build URL with query parameters
        var finalUrl = BuildUrlWithQueryParameters(url, config?.QueryParameters);
        
        var request = new HttpRequestMessage(method, finalUrl);

        // Add headers
        if (config?.Headers != null)
        {
            foreach (var header in config.Headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        // Add body for POST, PUT, PATCH
        if (body != null && (method == HttpMethod.Post || method == HttpMethod.Put || method == HttpMethod.Patch))
        {
            var json = JsonSerializer.Serialize(body, _jsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        // Apply authentication
        if (config?.Authentication != null)
        {
            await _authOrchestrator.ApplyAuthenticationAsync(request, config.Authentication, cancellationToken);
        }

        try
        {
            var response = await client.SendAsync(request, cancellationToken);
            return await ProcessResponseAsync<T>(response, cancellationToken);
        }
        catch (Exception ex)
        {
            return new HttpResponse<T>
            {
                IsSuccess = false,
                StatusCode = 0,
                ErrorMessage = ex.Message
            };
        }
    }

    private async Task<HttpResponse<T>> ProcessResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        var result = new HttpResponse<T>
        {
            IsSuccess = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Headers = response.Headers.ToDictionary(h => h.Key, h => h.Value)
        };

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        result.RawContent = content;

        if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(content))
        {
            try
            {
                if (typeof(T) == typeof(string))
                {
                    result.Data = (T)(object)content;
                }
                else
                {
                    result.Data = JsonSerializer.Deserialize<T>(content, _jsonOptions);
                }
            }
            catch (JsonException ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Failed to deserialize response: {ex.Message}";
            }
        }
        else if (!response.IsSuccessStatusCode)
        {
            result.ErrorMessage = $"Request failed with status code {response.StatusCode}: {content}";
        }

        return result;
    }

    private string BuildUrlWithQueryParameters(string url, Dictionary<string, string>? queryParameters)
    {
        if (queryParameters == null || !queryParameters.Any())
            return url;

        var uriBuilder = new UriBuilder(url);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        foreach (var param in queryParameters)
        {
            query[param.Key] = param.Value;
        }

        uriBuilder.Query = query.ToString();
        return uriBuilder.ToString();
    }
}