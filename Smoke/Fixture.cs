using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Opal.Services;

namespace Smoke
{
    public class Fixture
    {
        public void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<HealthCheckService>(SetupDefaultRequestHeaders);
            serviceCollection.AddHttpClient<AccountsService>(SetupDefaultRequestHeaders);
        }

        private static void SetupDefaultRequestHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("Connection", "close");
        }
    }
}