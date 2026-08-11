using Soenneker.Tests.HostedUnit;

namespace Soenneker.HealthSherpa.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class HealthSherpaOpenApiClientTests : HostedUnitTest
{
    public HealthSherpaOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
