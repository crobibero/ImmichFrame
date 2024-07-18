using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace Immich.Sdk;

/// <summary>
/// Immich request adapter.
/// </summary>
public sealed class ImmichRequestAdapter : HttpClientRequestAdapter
{
    private readonly ImmichSdkSettings _sdkSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImmichRequestAdapter"/> class.
    /// </summary>
    /// <param name="authenticationProvider">The authentication provider.</param>
    /// <param name="sdkSettings">The Immich sdk settings.</param>
    /// <param name="httpClient">The native HTTP client.</param>
    public ImmichRequestAdapter(
        IAuthenticationProvider authenticationProvider,
        ImmichSdkSettings sdkSettings,
        HttpClient? httpClient = null)
        : base(authenticationProvider, httpClient: httpClient)
    {
        _sdkSettings = sdkSettings;
        BaseUrl = _sdkSettings.ServerUrl;
        _sdkSettings.ServerUrlUpdated += OnServerUrlUpdated;
    }
    
    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _sdkSettings.ServerUrlUpdated -= OnServerUrlUpdated;
        }

        base.Dispose(disposing);
    }
    
    private void OnServerUrlUpdated(object? sender, TypedEventArgs<string?> e)
        => BaseUrl = e.Content;
}
