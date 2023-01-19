using Karaoke_api.AggregateModels.UserAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateUserBsonMapping()
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.MapCreator(c => new User(c.Id,c.Name,c.Phone,c.Gender,c.Address));

                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty(c => c.Name);
                cm.MapProperty(c => c.Phone);
                cm.MapProperty(c => c.Gender);
                cm.MapProperty(c => c.Address);
            });
        }
    }
}
