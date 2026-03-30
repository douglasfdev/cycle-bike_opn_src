using CycleBike.Adapters.Infrastructure.Middlewares;
using JasperFx.CodeGeneration.Frames;
using Wolverine;
using Wolverine.Configuration;
using Wolverine.Runtime.Handlers;

namespace CycleBike.Adapters.Infrastructure.Modules.Wolverine.Policies;

public class IdempotencyPolicy : IWolverinePolicy
{
    public void Apply(HandlerGraph graph, WolverineOptions rules)
    {
        foreach (var chain in graph.Chains)
        {
            chain.Middleware.Add(new MethodCall(
                typeof(IdempotencyMiddleware), 
                nameof(IdempotencyMiddleware.Before)));
        }
    }
}