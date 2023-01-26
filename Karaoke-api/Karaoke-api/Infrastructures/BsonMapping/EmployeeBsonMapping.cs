using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Karaoke_api.AggregateModels.EmployeeAggregates;

namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateEmployeeBsonMapping()
        {
            BsonClassMap.RegisterClassMap<Employee>(cm =>
            {
                cm.MapCreator(c => new Employee( c.Name,c.Address,c.Gender,c.Phone,c.RoleId,c.CountShift, c.Id));
                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty(c => c.Name);
                cm.MapProperty(c => c.Address);
                cm.MapProperty(c => c.Gender);
                cm.MapProperty(c => c.Phone);
                cm.MapProperty(c => c.CountShift);
                cm.MapProperty(c => c.RoleId).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }
}
