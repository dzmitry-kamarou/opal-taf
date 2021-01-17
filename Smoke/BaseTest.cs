using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Smoke
{
    public class BaseTest : IClassFixture<WebApplicationFactory<Fixture>>
    {
        protected readonly ServiceCollection Collection;

        protected BaseTest()
        {
            Collection = new ServiceCollection();
            new Fixture().ConfigureServices(Collection);
        }
    }
}