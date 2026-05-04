using Microsoft.Extensions.FileProviders;

namespace CycleBike.Adapters.OutboxRelay.Configuration;

public class HostEnvironmentAdapter(IHostEnvironment env) : IHostEnvironment
{
    public string ApplicationName { get; set; } = env.ApplicationName;
    public IFileProvider ContentRootFileProvider { get; set; } = env.ContentRootFileProvider;
    public string ContentRootPath { get; set; } = env.ContentRootPath;
    public string EnvironmentName { get; set; } = env.EnvironmentName;
}