using Karaoke_api.AggregateModels.RoomTypeAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Features.RoomTypeFeatures.RoomTypeQueries
{
    [ExtendObjectType(name: "Query")]
    public class RoomTypeQueries
    {
        [UseFiltering]
        [UseSorting]
        public IExecutable<RoomType> GetRoomTypes([Service] IMongoCollection<RoomType> collection)
        {
            return collection.AsExecutable();
        }
    }
}
