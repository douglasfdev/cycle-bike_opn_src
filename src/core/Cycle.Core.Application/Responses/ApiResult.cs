namespace Cycle.Core.Application.Responses;

public sealed record ApiResult<T>(
    bool IsSuccess,
    T? Data,
    string? Message,
    IReadOnlyCollection<string> Errors,
    int StatusCode)
{
    /// <summary>
    /// Sucesso com dados e status code.
    /// </summary>
    public static ApiResult<T> Success(T data, int statusCode = 200)
        => new(true, data, null, Array.Empty<string>(), statusCode);

    /// <summary>
    /// Sucesso com mensagem e status code (sem dados).
    /// </summary>
    public static ApiResult<T> Success(string message, int statusCode = 200)
        => new(true, default, message, Array.Empty<string>(), statusCode);

    /// <summary>
    /// Sucesso com mensagem, dados e status code.
    /// </summary>
    public static ApiResult<T> Success(string message, T data, int statusCode = 200)
        => new(true, data, message, Array.Empty<string>(), statusCode);



    /// <summary>
    /// Falha com mensagem única e status code.
    /// </summary>
    public static ApiResult<T> Failure(string error, int statusCode = 400)
        => new(false, default, null, new[] { error }, statusCode);

    /// <summary>
    /// Falha com múltiplas mensagens e status code.
    /// </summary>
    public static ApiResult<T> Failure(IEnumerable<string> errors, int statusCode = 400)
        => new(false, default, null, errors.ToArray(), statusCode);
}