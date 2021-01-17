using Opal.Services;
using Xunit;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;

namespace Smoke
{
    public class OpalHeathCheckServiceTest : BaseTest
    {
        private readonly HealthCheckService _service;

        public OpalHeathCheckServiceTest()
        {
            _service = Collection.BuildServiceProvider().GetService<HealthCheckService>();
        }

        [Fact]
        public async Task HealthCheck_GetHealthCheck_ReturnsHealth()
        {
            (await _service.RetrieveHealthCheckAsync())
                .Should()
                .BeEquivalentTo("Welcome to the Opal, it's feeling good!", "Opal has launched up");
        }
    }
}