using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;

namespace CycleBike.Core.Common.Logging;

public static class LoggerCommon
{
    public static ILoggingBuilder AddOpenTelemetryDomainInjection(this ILoggingBuilder builder)
    {
        builder.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
            logging.AddOtlpExporter();
        });
        return builder;
    }
}