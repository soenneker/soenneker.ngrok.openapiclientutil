using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.ngrok.HttpClients.Abstract;
using Soenneker.ngrok.OpenApiClientUtil.Abstract;
using Soenneker.Ngrok.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ngrok.OpenApiClientUtil;

/// <inheritdoc cref="IngrokOpenApiClientUtil" />
public sealed class ngrokOpenApiClientUtil : IngrokOpenApiClientUtil
{
    private readonly AsyncSingleton<NgrokOpenApiClient> _client;

    public ngrokOpenApiClientUtil(IngrokOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<NgrokOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new NgrokOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<NgrokOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
