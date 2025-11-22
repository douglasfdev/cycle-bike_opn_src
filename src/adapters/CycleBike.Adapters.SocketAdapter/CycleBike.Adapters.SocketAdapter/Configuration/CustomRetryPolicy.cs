using Microsoft.AspNetCore.SignalR.Client;

namespace CycleBike.Adapters.SocketAdapter.Configuration;

internal sealed class CustomRetryPolicy(int[] delays) : IRetryPolicy
{
    public TimeSpan? NextRetryDelay(RetryContext retryContext)
    {
        if (retryContext.PreviousRetryCount >= delays.Length)
            return TimeSpan.FromSeconds(30);

        return TimeSpan.FromMilliseconds(delays[retryContext.PreviousRetryCount]);
    }
}