using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.ngrok.HttpClients.Abstract;
using Soenneker.ngrok.OpenApiClientUtil.Abstract;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Ngrok.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ngrok.OpenApiClientUtil;

///<inheritdoc cref="IngrokOpenApiClientUtil"/>
public sealed class ngrokOpenApiClientUtil : IngrokOpenApiClientUtil
{
    private readonly AsyncSingleton<NgrokOpenApiClient> _client;

    public ngrokOpenApiClientUtil(IngrokOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<NgrokOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("ngrok:ApiKey");
            string authHeaderValueTemplate = configuration["ngrok:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
