using Soenneker.Ngrok.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.ngrok.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached ngrok API client backed by the configured HTTP provider.
/// </summary>
public interface IngrokOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached ngrok client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured ngrok client.</returns>
    ValueTask<NgrokOpenApiClient> Get(CancellationToken cancellationToken = default);
}
