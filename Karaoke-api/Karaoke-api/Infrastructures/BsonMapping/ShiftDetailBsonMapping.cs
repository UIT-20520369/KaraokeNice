using Karaoke_api.AggregateModels.ShiftDetailAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateShiftDetailBsonMapping()
        {
            BsonClassMap.RegisterClassMap<ShiftDetail>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(c => new ShiftDetail(c.ShiftId,c.EmployeeId,c.WorkDay,c.Id));
                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty("ShiftId").SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty("EmployeeId").SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }
}
