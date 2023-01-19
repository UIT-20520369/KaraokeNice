using Karaoke_api.AggregateModels.RoleAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateRoleBsonMapping()
        {
            BsonClassMap.RegisterClassMap<Role>(cm =>
            {
                cm.MapCreator(c => new Role(c.Id, c.Name, c.Code));

                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty(c => c.Name);
                cm.MapProperty(c => c.Code);
            });
        }
    }
}
