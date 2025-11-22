namespace CycleBike.Core.Common.Utils;

public static class ArgumentGuard
{
    
    public static string ThrowIfIsNullOrEmpty(string? value, string argument)
    {
        return string.IsNullOrEmpty(value) ? throw new ArgumentException($"{argument} is required") : value;
    }

    public static void AgainstNullOrWhiteSpace(string? value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"O argumento '{paramName}' não pode ser vazio.");
    }

    public static void AgainstNullOrNegative(int? value, string paramName)
    {
        if (value == null || value <= 0)
            throw new ArgumentException($"O argumento '{paramName}' não pode ser nulo, zero ou negativo.");
    }
    
    public static void AgainstNullOrNegative(decimal? value, string paramName)
    {
        if (value == null || value <= 0)
            throw new ArgumentException($"O argumento '{paramName}' não pode ser nulo, zero ou negativo.");
    }
}