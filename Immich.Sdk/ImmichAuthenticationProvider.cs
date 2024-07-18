using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace Immich.Sdk;

/// <summary>
/// Authentication provider for Immich.
/// </summary>
public sealed class ImmichAuthenticationProvider : IAuthenticationProvider
{
    private const string HeaderName = "X-API-KEY";
    private readonly ImmichSdkSettings _sdkSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImmichAuthenticationProvider"/> class.
    /// </summary>
    /// <param name="sdkSettings">The Immich sdk settings.</param>
    public ImmichAuthenticationProvider(ImmichSdkSettings sdkSettings)
    {
        _sdkSettings = sdkSettings;
    }
    
    /// <inheritdoc />
    public Task AuthenticateRequestAsync(
        RequestInformation request,
        Dictionary<string, object>? additionalAuthenticationContext = null,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (!string.IsNullOrEmpty(_sdkSettings.ApiKey))
        {
            request.Headers.Add(HeaderName, _sdkSettings.ApiKey);    
        }

        return Task.CompletedTask;
    }
}
