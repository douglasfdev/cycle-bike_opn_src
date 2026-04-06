using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql;

public static class Conversions
{
    public class UlidToStringConverter() : ValueConverter<Ulid, string>(
        v => v.ToString(),
        v => Ulid.Parse(v)
    );
}