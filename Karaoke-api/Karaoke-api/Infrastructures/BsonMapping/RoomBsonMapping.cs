using Karaoke_api.AggregateModels.RoomAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateRoomBsonMapping()
        {
            BsonClassMap.RegisterClassMap<Room>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(c => new Room(c.Number,c.TypeId, c.Id));
                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty("TypeId").SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }
}
