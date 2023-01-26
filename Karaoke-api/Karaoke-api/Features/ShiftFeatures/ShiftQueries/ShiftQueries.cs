using Karaoke_api.AggregateModels.ShiftAggregates;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Karaoke_api.Features.ShiftFeatures.ShiftQueries
{
    [ExtendObjectType(name: "Query")]
    public class ShiftQueries
    {
        [UseFiltering]
        [UseSorting]
        public IExecutable<Shift> GetShift([Service] IMongoCollection<Shift> collection)
        {
            return collection.AsExecutable();
        }
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IExecutable<Shift> GetShiftWithPagination([Service] IMongoCollection<Shift> collection)
        {
            return collection.AsExecutable();
        }
        
    }
}
