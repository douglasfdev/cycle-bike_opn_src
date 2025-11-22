namespace CycleBike.Adapters.GenericHttpClient.Models;

public class HttpResponse<T>
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public Dictionary<string, IEnumerable<string>> Headers { get; set; } = new();
    public string? RawContent { get; set; }
}