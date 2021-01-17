using System.Net.Http;
using System.Threading.Tasks;

namespace Opal.Services
{
    public class HealthCheckService : BaseService
    {
        private const string HealthCheckEndpoint = "healthcheck";

        public HealthCheckService(HttpClient client) : base(client)
        {
        }

        public async Task<string> RetrieveHealthCheckAsync()
        {
            var response = await Client.GetAsync($"{HealthCheckEndpoint}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}