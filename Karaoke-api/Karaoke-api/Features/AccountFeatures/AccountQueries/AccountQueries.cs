using Karaoke_api.AggregateModels.AccountAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Features.AccountFeatures.AccountQueries
{
    [ExtendObjectType(name: "Query")]
    
    public class AccountQueries
    {
        [UseFiltering]
        [UseSorting]
        public IExecutable<Account> GetAccounts([Service] IMongoCollection<Account> collection) {
            return collection.AsExecutable();
        }
    }
}
