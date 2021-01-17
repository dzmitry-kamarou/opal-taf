using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Opal.Model.Accounts;
using Opal.Services;
using Xunit;

namespace Smoke
{
    public class OpalAccountsServiceTest : BaseTest, IDisposable
    {
        private readonly AccountsService _service;
        private readonly Account _account;

        public OpalAccountsServiceTest()
        {
            _service = Collection.BuildServiceProvider().GetService<AccountsService>();
            _account = AccountFactory.RandomValidAccount();
        }

        [Fact]
        public async Task Accounts_GetAccount_ReturnsAccount()
        {
            _account.Id = (await _service.CreateAccountAsync(_account)).Id;

            (await _service.RetrieveAccountAsync(_account))
                .Should()
                .BeEquivalentTo(_account, $"Account '{_account.Id}' was created");
        }

        public void Dispose()
        {
            _service.RemoveAccountAsync(_account);
        }
    }
}