using Soenneker.ngrok.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.ngrok.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class ngrokOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IngrokOpenApiClientUtil _openapiclientutil;

    public ngrokOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IngrokOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
