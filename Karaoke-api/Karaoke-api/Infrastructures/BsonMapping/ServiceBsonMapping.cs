using Karaoke_api.AggregateModels.RoleAggregates;
using Karaoke_api.AggregateModels.ServiceAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateServiceBsonMapping()
        {
            BsonClassMap.RegisterClassMap<Service>(cm =>
            {
                cm.MapCreator(c => new Service(c.Id,c.Name,c.Type,c.Thumbnail));

                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty(c => c.Name);
                cm.MapProperty(c => c.Type);
                cm.MapProperty(c => c.Thumbnail);
            });
        }
    }
}
