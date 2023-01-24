using MongoDB.Driver;
using Karaoke_api.AggregateModels.ServiceAggregates;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Karaoke_api.Features.ServiceFeatures.ServiceQueries
{
    [ExtendObjectType(name: "Query")]
    public class ServiceQueries
    {
        [UseFiltering]
        [UseSorting]
        public IExecutable<Service> GetService([Service] IMongoCollection<Service> collection)
        {
            return collection.AsExecutable();
        }
    }
}
