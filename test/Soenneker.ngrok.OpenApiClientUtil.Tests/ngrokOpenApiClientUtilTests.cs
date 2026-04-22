using Soenneker.ngrok.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.ngrok.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ngrokOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IngrokOpenApiClientUtil _openapiclientutil;

    public ngrokOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IngrokOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
