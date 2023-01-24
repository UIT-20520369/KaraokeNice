using Karaoke_api.AggregateModels.Seedwork;
using Karaoke_api.AggregateModels.AccountAggregates;
namespace Karaoke_api.AggregateModels.AccountAggregates
{
    public interface IAccountRepository:IRepository<Account>
    {
        public Account AddAccount(Account account);
        public void UpdateAccount(Account account);
        public void DeleteAccount(Account account);
    }
}
