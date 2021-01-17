using Bogus;

namespace Opal.Model.Accounts
{
    public static class AccountFactory
    {
        public static Account RandomValidAccount()
        {
            return new Faker<Account>()
                .RuleFor(a => a.FirstName, f => f.Name.FirstName())
                .RuleFor(a => a.LastName, f => f.Name.LastName())
                .Generate();
        }
    }
}