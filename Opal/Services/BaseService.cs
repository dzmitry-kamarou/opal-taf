using System;
using System.Net.Http;

namespace Opal.Services
{
    public class BaseService
    {
        private const string BaseUri = "https://localhost:5001/api/";
        protected readonly HttpClient Client;

        protected BaseService(HttpClient client)
        {
            Client = client;
            Client.BaseAddress = new Uri(BaseUri);
        }
    }
}