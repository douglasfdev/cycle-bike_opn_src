using System.Diagnostics.CodeAnalysis;
using HotChocolate.Language;

namespace CycleBike.Adapters.GraphQL.Scalars;

public class UlidScalar : ScalarType<Ulid, StringValueNode>
{
    public UlidScalar() : base("Ulid", BindingBehavior.Implicit)
    {
    }

    public override IValueNode ParseResult(object? resultValue)
    {
        return resultValue is Ulid ulid
            ? new StringValueNode(ulid.ToString())
            : throw new SerializationException($"Cannot serialize {resultValue?.GetType().Name ?? "null"} as Ulid", this);
    }

    protected override Ulid ParseLiteral(StringValueNode valueSyntax)
    {
        return Ulid.TryParse(valueSyntax.Value, out var ulid)
            ? ulid
            : throw new SerializationException("Invalid Ulid format", this);
    }

    protected override StringValueNode ParseValue(Ulid runtimeValue)
    {
        return new StringValueNode(runtimeValue.ToString());
    }

    public override bool TrySerialize(object? runtimeValue, [UnscopedRef] out object? resultValue)
    {
        if (runtimeValue is Ulid ulid)
        {
            resultValue = ulid.ToString();
            return true;
        }

        resultValue = null;
        return false;
    }

    public override bool TryDeserialize(object? resultValue, [UnscopedRef] out object? runtimeValue)
    {
        if (resultValue is string s && Ulid.TryParse(s, out var ulid))
        {
            runtimeValue = ulid;
            return true;
        }

        runtimeValue = null;
        return false;
    }
}
