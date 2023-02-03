using Karaoke_api.AggregateModels.BookingAggregates;
using Karaoke_api.AggregateModels.ShiftDetailAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateBookingBsonMapping()
        {
            BsonClassMap.RegisterClassMap<Booking>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(c => new Booking(c.UserId,c.RoomId,c.Request,c.CreatedAt,c.CheckIn,c.CheckOut,c.Deposit,c.Total,c.Id));
                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty("UserId").SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty("RoomId").SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }
}
