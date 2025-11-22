using System.Text;
using System.Text.Json;

namespace CycleBike.Adapters.GenericHttpClient.Abstractions;

public class BaseHttpClient(HttpClient httpClient) : IDisposable
{
    private readonly HttpClient _httpClient = httpClient;

    public readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly Dictionary<string, string> _defaultHeaders = new Dictionary<string, string>();

    public BaseHttpClient(HttpClient httpClient, Dictionary<string, string> defaultHeaders) : this(httpClient)
    {
        _defaultHeaders = defaultHeaders ?? new Dictionary<string, string>();
        ApplyDefaultHeaders();
    }

    public TimeSpan Timeout
    {
        get => _httpClient.Timeout;
        set => _httpClient.Timeout = value;
    }

    public Uri? BaseAddress
    {
        get => _httpClient.BaseAddress;
        set => _httpClient.BaseAddress = value;
    }

    public JsonSerializerOptions JsonOptions => _jsonOptions;

    // Adicionar header padrão
    public BaseHttpClient AddDefaultHeader(string name, string value)
    {
        _defaultHeaders[name] = value;
        _httpClient.DefaultRequestHeaders.Remove(name);
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(name, value);
        return this;
    }

    // Adicionar múltiplos headers padrão
    public BaseHttpClient AddDefaultHeaders(Dictionary<string, string> headers)
    {
        foreach (var header in headers)
        {
            AddDefaultHeader(header.Key, header.Value);
        }

        return this;
    }

    // Remover header padrão
    public BaseHttpClient RemoveDefaultHeader(string name)
    {
        _defaultHeaders.Remove(name);
        _httpClient.DefaultRequestHeaders.Remove(name);
        return this;
    }

    // Limpar todos os headers padrão
    public BaseHttpClient ClearDefaultHeaders()
    {
        _defaultHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Clear();
        return this;
    }

    // GET
    public async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Get, url, headers);
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    public async Task<T?> GetAsync<T>(string url, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        var response = await GetAsync(url, headers, cancellationToken);
        return await DeserializeResponseAsync<T>(response, cancellationToken);
    }

    public async Task<string> GetStringAsync(string url, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        var response = await GetAsync(url, headers, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    // POST
    public async Task<HttpResponseMessage> PostAsync(string url, object? body = null,
        Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Post, url, headers, body);
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    public async Task<T?> PostAsync<T>(string url, object? body = null, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        var response = await PostAsync(url, body, headers, cancellationToken);
        return await DeserializeResponseAsync<T>(response, cancellationToken);
    }

    public async Task<HttpResponseMessage> PostJsonAsync(string url, string jsonContent,
        Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Post, url, headers);
        request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    public async Task<HttpResponseMessage> PostFormAsync(string url, Dictionary<string, string> formData,
        Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Post, url, headers);
        request.Content = new FormUrlEncodedContent(formData);
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    // PUT
    public async Task<HttpResponseMessage> PutAsync(string url, object? body = null,
        Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Put, url, headers, body);
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    public async Task<T?> PutAsync<T>(string url, object? body = null, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        var response = await PutAsync(url, body, headers, cancellationToken);
        return await DeserializeResponseAsync<T>(response, cancellationToken);
    }

    // DELETE
    public async Task<HttpResponseMessage> DeleteAsync(string url, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Delete, url, headers);
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    public async Task<T?> DeleteAsync<T>(string url, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        var response = await DeleteAsync(url, headers, cancellationToken);
        return await DeserializeResponseAsync<T>(response, cancellationToken);
    }

    // PATCH
    public async Task<HttpResponseMessage> PatchAsync(string url, object? body = null,
        Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Patch, url, headers, body);
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    public async Task<T?> PatchAsync<T>(string url, object? body = null, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        var response = await PatchAsync(url, body, headers, cancellationToken);
        return await DeserializeResponseAsync<T>(response, cancellationToken);
    }

    // HEAD
    public async Task<HttpResponseMessage> HeadAsync(string url, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Head, url, headers);
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    // OPTIONS
    public async Task<HttpResponseMessage> OptionsAsync(string url, Dictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Options, url, headers);
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    // Método genérico para qualquer verbo HTTP
    public async Task<HttpResponseMessage> SendAsync(HttpMethod method, string url, object? body = null,
        Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(method, url, headers, body);
        return await _httpClient.SendAsync(request, cancellationToken);
    }

    public async Task<T?> SendAsync<T>(HttpMethod method, string url, object? body = null,
        Dictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        var response = await SendAsync(method, url, body, headers, cancellationToken);
        return await DeserializeResponseAsync<T>(response, cancellationToken);
    }

    // Helpers privados
    private HttpRequestMessage CreateRequest(HttpMethod method, string url, Dictionary<string, string>? headers = null,
        object? body = null)
    {
        var request = new HttpRequestMessage(method, url);

        // Aplicar headers específicos da requisição
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        // Adicionar body se necessário
        if (body != null && (method == HttpMethod.Post || method == HttpMethod.Put || method == HttpMethod.Patch))
        {
            var json = JsonSerializer.Serialize(body, _jsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        return request;
    }

    private async Task<T?> DeserializeResponseAsync<T>(HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        if (string.IsNullOrEmpty(content))
            return default;

        if (typeof(T) == typeof(string))
            return (T)(object)content;

        return JsonSerializer.Deserialize<T>(content, _jsonOptions);
    }

    private void ApplyDefaultHeaders()
    {
        foreach (var header in _defaultHeaders)
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}
