using Karaoke_api.AggregateModels.BookingAggregates;
using Karaoke_api.AggregateModels.RoomTypeAggregates;
using Karaoke_api.AggregateModels.UserAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Features.BookingFeatures.BookingQueries
{
    [ExtendObjectType(name:"Query")]
    public class BookingQueries
    {
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IExecutable<Booking> GetBookings ([Service] IMongoCollection<Booking> collection,[Service] IMongoCollection<User> userCollection, [Service] IMongoCollection<RoomType> roomCollection )
        {
            return collection.Aggregate().Lookup<Booking, RoomType, Booking>(roomCollection
                , b => b.RoomId
                , r => r.Id
                , o => o.RoomType).Unwind<Booking, Booking>(o => o.RoomType)
                .Lookup<Booking, User, Booking>(userCollection
                , b => b.UserId
                , u => u.Id
                , o => o.Customer).Unwind<Booking, Booking>(o => o.Customer).AsExecutable();
        }
    }
}
