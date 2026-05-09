using Grpc.Core;

namespace CycleBike.Adapters.gRPC.Services;

public class HealthCheck() : HealthCheckService.HealthCheckServiceBase
{
    public override async Task<HealthCheckResponse> Check(HealthCheckRequest request, ServerCallContext context)
    {
        return await Task.FromResult(new HealthCheckResponse
        {
            Status = HealthCheckResponse.Types.ServingStatus.Serving,
            Message = "Sistema operando normalmente",
            Version = "1.0.0",
            Timestamp = DateTime.UtcNow.ToString("O")
        });
    }
    
    public override async Task Watch(HealthCheckRequest request, IServerStreamWriter<HealthCheckResponse> responseStream, ServerCallContext context)
    {
        while (!context.CancellationToken.IsCancellationRequested)
        {
            await responseStream.WriteAsync(new HealthCheckResponse { Status = HealthCheckResponse.Types.ServingStatus.Serving });
            await Task.Delay(5000);
        }
    }
}