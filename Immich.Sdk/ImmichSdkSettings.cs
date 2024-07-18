namespace Immich.Sdk;

public sealed class ImmichSdkSettings
{
    /// <summary>
    /// The event that fires when the server url is updated.
    /// </summary>
    public event EventHandler<TypedEventArgs<string?>>? ServerUrlUpdated;

    /// <summary>
    /// Gets the Immich server's base url.
    /// </summary>
    public string? ServerUrl { get; private set; }
    
    /// <summary>
    /// Gets the Immich api key.
    /// </summary>
    public string? ApiKey { get; private set; }
    
    /// <summary>
    /// Set the server url.
    /// </summary>
    /// <param name="serverUrl">The server url.</param>
    public void SetServerUrl(string? serverUrl)
    {
        ServerUrl = serverUrl;
        ServerUrlUpdated?.Invoke(this, new TypedEventArgs<string?>(serverUrl));
    }

    /// <summary>
    /// Set the api key.
    /// </summary>
    /// <param name="apiKey">The api key.</param>
    public void SetApiKey(string? apiKey)
    {
        ApiKey = apiKey;
    }
}
