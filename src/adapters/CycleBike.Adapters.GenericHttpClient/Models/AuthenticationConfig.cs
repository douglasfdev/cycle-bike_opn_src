using CycleBike.Adapters.GenericHttpClient.Enums;

namespace CycleBike.Adapters.GenericHttpClient.Models;

public class AuthenticationConfig
{
    public AuthenticationType Type { get; set; } = AuthenticationType.None;

    #region Basic Auth

    public string? Username { get; set; }
    public string? Password { get; set; }
    #endregion

    #region Bearer / JWT Bearer

    public string? Token { get; set; }

    #endregion

    #region API Key

    public string? ApiKeyName { get; set; }
    public string? ApiKeyValue { get; set; }
    public ApiKeyLocation ApiKeyLocation { get; set; } = ApiKeyLocation.Header;

    #endregion

    #region OAuth2

    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? TokenEndpoint { get; set; }
    public string? Scope { get; set; }
    public string? GrantType { get; set; } = "client_credentials";

    #endregion
}