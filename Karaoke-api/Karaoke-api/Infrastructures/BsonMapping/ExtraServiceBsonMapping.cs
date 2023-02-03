using Karaoke_api.AggregateModels.AccountAggregates;
using Karaoke_api.AggregateModels.ExtraServiceAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateExtraServiceBsonMapping()
        {
            BsonClassMap.RegisterClassMap<ExtraService>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(c => new ExtraService(c.Name, c.Price, c.Unit, c.Id));
                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }
}
