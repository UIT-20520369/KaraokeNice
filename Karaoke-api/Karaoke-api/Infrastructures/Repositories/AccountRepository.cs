using Karaoke_api.AggregateModels.AccountAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Infrastructures.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        IMongoCollection<Account> _accounts;
        public AccountRepository(IMongoCollection<Account> accounts)
        {
            _accounts = accounts;
        }
        public Account AddAccount(Account account) { 
        _accounts.InsertOne(account);
            return account;
        }
        public void DeleteAccount(Account account)
        {
            _accounts.DeleteOne(acc =>acc.Id == account.Id);
        }
        public void UpdateAccount(Account account) {
            var accDoc = _accounts.Find(acc => acc.Id == account.Id).FirstOrDefault();
            if (accDoc != null)
            {
                accDoc.Update(account);
                _accounts.ReplaceOne(acc => acc.Id == account.Id, accDoc);
            }
            else
            {
                throw new Exception("Account doesn't exist in database");
            }    
        }
    }
}
