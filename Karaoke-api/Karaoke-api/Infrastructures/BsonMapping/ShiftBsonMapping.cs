using Karaoke_api.AggregateModels.EmployeeAggregates;
using Karaoke_api.AggregateModels.ShiftAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateShiftBsonMapping()
        {
            BsonClassMap.RegisterClassMap<Shift>(cm =>
            {
                cm.MapCreator(c => new Shift(c.ShiftName,c.StartTime,c.EndTime,c.Id));
                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty(c => c.ShiftName);
                cm.MapProperty(c => c.StartTime);
                cm.MapProperty(c => c.EndTime);
            });
        }
    }
}
