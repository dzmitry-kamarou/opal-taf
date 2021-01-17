using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Opal.Model.Accounts;

namespace Opal.Services
{
    public class AccountsService : BaseService
    {
        private const string AccountsEndpoint = "accounts";

        public AccountsService(HttpClient client) : base(client)
        {
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            var payload = JsonSerializer.Serialize(new Dictionary<string, object>
            {
                {"firstName", account.FirstName},
                {"lastName", account.LastName}
            });
            var response = await Client.PostAsync(AccountsEndpoint, ProceedPayload(payload));
            return JsonSerializer.Deserialize<Account>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Account> RetrieveAccountAsync(Account account)
        {
            var response = await Client.GetAsync($"{AccountsEndpoint}/{account.Id}");
            return response.StatusCode == HttpStatusCode.NotFound
                ? null
                : JsonSerializer.Deserialize<Account>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Account> RemoveAccountAsync(Account account)
        {
            var response = await Client.DeleteAsync($"{AccountsEndpoint}/{account.Id}");
            return JsonSerializer.Deserialize<Account>(await response.Content.ReadAsStringAsync());
        }

        private static StringContent ProceedPayload(string content)
        {
            return new StringContent(content, Encoding.UTF8, "application/json");
        }
    }
}