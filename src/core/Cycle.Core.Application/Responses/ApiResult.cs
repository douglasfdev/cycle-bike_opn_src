namespace Cycle.Core.Application.Responses;

public record ApiResult<T>(
    bool IsSuccess,
    T? Data,
    string? Message,
    IReadOnlyCollection<string> Errors,
    int StatusCode)
{
    public static ApiResult<T> Success(T data, int statusCode = 200)
        => new(true, data, null, Array.Empty<string>(), statusCode);

    public static ApiResult<T> Success(string message, int statusCode = 200)
        => new(true, default, message, Array.Empty<string>(), statusCode);

    public static ApiResult<T> Success(string message, T data, int statusCode = 200)
        => new(true, data, message, Array.Empty<string>(), statusCode);

    public static ApiResult<T> Failure(string error, int statusCode = 400)
        => new(false, default, null, [error], statusCode);

    public static ApiResult<T> Failure(IEnumerable<string> errors, int statusCode = 400)
        => new(false, default, null, errors.ToList().AsReadOnly(), statusCode);
}