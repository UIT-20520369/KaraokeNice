using Karaoke_api.AggregateModels.AccountAggregates;
using Karaoke_api.Infrastructures.Repositories;
namespace Karaoke_api.Features.AccountFeatures.AccountMutations
{
    public class AccountMutations
    {
        private readonly IAccountRepository _accountRepository;
        public AccountMutations(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public string CreateAccount(string username, string password)
        {
            var acc = new Account(username,password);
            var temp =_accountRepository.AddAccount(acc);
            return temp.Id;
        }
        public string UpdateAccount(string id,string? username, string? password)
        {
            var acc = new Account(username,password);
            _accountRepository.UpdateAccount(acc);
            return acc.Id;
        }
        public string DeleteAccount(string id, string? username, string? password)
        {
            var acc = new Account(username, password);
            _accountRepository.DeleteAccount(acc);
            return acc.Id;
        }
    }
}
