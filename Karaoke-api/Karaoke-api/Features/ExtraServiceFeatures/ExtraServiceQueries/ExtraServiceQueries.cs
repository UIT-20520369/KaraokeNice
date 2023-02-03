using Karaoke_api.AggregateModels.ExtraServiceAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Features.ExtraServiceFeatures.ExtraServiceQueries
{

    [ExtendObjectType(name: "Query")]
    public class ExtraServiceQueries
    {
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IExecutable<ExtraService> GetExtraServices([Service] IMongoCollection<ExtraService> collection)
        {
            return collection.AsExecutable();
        }
    }
}
