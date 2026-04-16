namespace CycleBike.Adapters.GraphQL.ErrorHandling;

public class GraphQLErrorFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        if (error.Exception is not null)
        {
            return error
                .WithMessage(error.Exception.Message)
                .WithCode(error.Exception.GetType().Name);
        }

        return error;
    }
}
