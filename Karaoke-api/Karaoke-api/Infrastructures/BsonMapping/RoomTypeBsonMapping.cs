using Karaoke_api.AggregateModels.RoomTypeAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateRoomTypeBsonMapping()
        {
            BsonClassMap.RegisterClassMap<RoomType>(cm =>
            {
                cm.MapCreator(c => new RoomType( c.Name,c.Description,c.Gallery,c.Guests,c.Price,c.Services,c.Thumnail,c.ShortContent,c.Areas,c.Id));

                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty(c => c.Name);
                cm.MapProperty(c => c.Description);
                cm.MapProperty(c => c.Guests);
                cm.MapProperty(c => c.Price);
                cm.MapProperty(c => c.Gallery);
                cm.MapProperty(c => c.Services);
                cm.MapProperty(c => c.Thumnail);
                cm.MapProperty(c => c.ShortContent);
                cm.MapProperty(c => c.Areas);
            });
        }
    }
}
