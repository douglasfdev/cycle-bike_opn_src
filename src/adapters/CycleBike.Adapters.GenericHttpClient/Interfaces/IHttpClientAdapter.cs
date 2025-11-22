using CycleBike.Adapters.GenericHttpClient.Models;

namespace CycleBike.Adapters.GenericHttpClient.Interfaces;

public interface IHttpClientAdapter
{
    Task<HttpResponse<T>> GetAsync<T>(
        string url,
        HttpRequestConfig? config = null,
        CancellationToken cancellationToken = default);
    
    Task<HttpResponse<string>> GetAsync(
        string url,
        HttpRequestConfig? config = null,
        CancellationToken cancellationToken = default);
    
    Task<HttpResponse<T>> PostAsync<T>(
        string url,
        object? body = null,
        HttpRequestConfig? config = null, CancellationToken cancellationToken = default);
    
    Task<HttpResponse<T>> PutAsync<T>(
        string url,
        object? body = null,
        HttpRequestConfig? config = null, CancellationToken cancellationToken = default);
    
    Task<HttpResponse<T>> DeleteAsync<T>(
        string url,
        HttpRequestConfig? config = null,
        CancellationToken cancellationToken = default);
    
    Task<HttpResponse<string>> DeleteAsync(
        string url,
        HttpRequestConfig? config = null,
        CancellationToken cancellationToken = default);
    
    Task<HttpResponse<T>> PatchAsync<T>(
        string url,
        object? body = null,
        HttpRequestConfig? config = null, CancellationToken cancellationToken = default);
}