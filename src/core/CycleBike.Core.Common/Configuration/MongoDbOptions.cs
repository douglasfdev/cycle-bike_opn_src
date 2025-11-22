namespace CycleBike.Core.Common.Configuration;

public class MongoDbOptions
{
    public required string ConnectionString { get; init; }
    public required string Database { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
}