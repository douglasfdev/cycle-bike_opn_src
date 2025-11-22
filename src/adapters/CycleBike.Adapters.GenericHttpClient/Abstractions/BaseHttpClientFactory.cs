namespace CycleBike.Adapters.GenericHttpClient.Abstractions;

public class BaseHttpClientFactory(IHttpClientFactory httpClientFactory)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    
    public BaseHttpClient CreateClient(string? name = null)
    {
        var httpClient = string.IsNullOrEmpty(name) 
            ? _httpClientFactory.CreateClient() 
            : _httpClientFactory.CreateClient(name);
        
        return new BaseHttpClient(httpClient);
    }

    public BaseHttpClient CreateClient(Dictionary<string, string> defaultHeaders, string? name = null)
    {
        var httpClient = string.IsNullOrEmpty(name) 
            ? _httpClientFactory.CreateClient() 
            : _httpClientFactory.CreateClient(name);
        
        return new BaseHttpClient(httpClient, defaultHeaders);
    }

    public BaseHttpClient CreateClient(Action<BaseHttpClient> configure, string? name = null)
    {
        var client = CreateClient(name);
        configure(client);
        return client;
    }
}