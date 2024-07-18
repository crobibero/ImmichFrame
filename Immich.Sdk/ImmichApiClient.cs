using Immich.Sdk.Generated;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Extensions;

namespace Immich.Sdk;

public sealed class ImmichApiClient : BaseImmichApiClient, IDisposable
{
    private readonly IRequestAdapter _requestAdapter;
    
    /// <inheritdoc />
    public ImmichApiClient(IRequestAdapter requestAdapter)
        : base(requestAdapter)
    {
        _requestAdapter = requestAdapter;
    }
    
    /// <summary>
    /// Build the uri from the request information.
    /// </summary>
    /// <param name="requestInformation">The request information.</param>
    /// <returns>The built uri.</returns>
    public Uri BuildUri(RequestInformation requestInformation)
    {
        if (!string.IsNullOrEmpty(_requestAdapter.BaseUrl))
        {
            requestInformation.PathParameters.AddOrReplace("baseurl", _requestAdapter.BaseUrl!);
        }

        return requestInformation.URI;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (_requestAdapter is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
