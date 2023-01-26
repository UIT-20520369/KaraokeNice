using Karaoke_api.AggregateModels.RoomAggregates;
using Karaoke_api.AggregateModels.RoomTypeAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Features.RoomFeatures.RoomQueries
{
    [ExtendObjectType(name: "Query")]
    public class RoomQueries
    {
        [UseFiltering]
        [UseSorting]
        public IExecutable<Room> GetRooms([Service] IMongoCollection<Room> roomCollection, [Service] IMongoCollection<RoomType> roomTypeCollection)
        {
           return roomCollection.Aggregate().Lookup<Room,RoomType,Room>(roomTypeCollection
                , r=> r.TypeId
                , rt => rt.Id
                , res => res.RoomType).Unwind<Room,Room>( r=>r.RoomType).AsExecutable();
        }

        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IExecutable<Room> GetRoomsWithPagination([Service] IMongoCollection<Room> roomCollection, [Service] IMongoCollection<RoomType> roomTypeCollection)
        {
            return roomCollection.Aggregate().Lookup<Room, RoomType, Room>(roomTypeCollection
                 , r => r.TypeId
                 , rt => rt.Id
                 , res => res.RoomType).Unwind<Room, Room>(r => r.RoomType).AsExecutable();
        }
    }
}
