﻿using Karaoke_api.AggregateModels.AccountAggregates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateAccountBsonMapping()
        {
            BsonClassMap.RegisterClassMap<Account>(cm =>
            {
                cm.MapCreator(c => new Account( c.Username, c.Password, c.Id));

                cm.MapIdProperty("Id").SetIdGenerator(new StringObjectIdGenerator()).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapProperty(c => c.Username);
                cm.MapProperty(c => c.Password);
            });
        }
    }
}
