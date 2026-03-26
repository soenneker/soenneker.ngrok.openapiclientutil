using Soenneker.Ngrok.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.ngrok.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IngrokOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<NgrokOpenApiClient> Get(CancellationToken cancellationToken = default);
}
