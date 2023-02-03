using MongoDB.Driver;
using Karaoke_api.AggregateModels.UserAggregates;
using Karaoke_api.AggregateModels.RoleAggregates;
using Karaoke_api.AggregateModels.EmployeeAggregates;
using Karaoke_api.AggregateModels.RoomTypeAggregates;
using Karaoke_api.AggregateModels.ServiceAggregates;
using Karaoke_api.AggregateModels.AccountAggregates;
using Karaoke_api.AggregateModels.ShiftAggregates;
using Karaoke_api.AggregateModels.ShiftDetailAggregates;
using Karaoke_api.AggregateModels.RoomAggregates;
using Karaoke_api.AggregateModels.ExtraServiceAggregates;
using Karaoke_api.AggregateModels.BookingAggregates;
namespace Karaoke_api.DbContext
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddMongoCollection<T>(this IServiceCollection services, string collectionName, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            if (connectionString == null)
                connectionString = configuration["MongoDatabase:ConnectionString"];
            services
              .AddSingleton(sp =>
              {
                  var mongoConnectionUrl = new MongoUrl(connectionString);
                  var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);
                  var client = new MongoClient(mongoClientSettings);
                  var database = client.GetDatabase(configuration["MongoDatabase:DatabaseName"]);
                  return database.GetCollection<T>(collectionName);
              });

            return services;
        }
        public static IServiceCollection AddMongoQueriesCollections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoCollection<User>("User", configuration);
            services.AddMongoCollection<Role>("Role", configuration);
            services.AddMongoCollection<Employee>("Employee", configuration);
            services.AddMongoCollection<RoomType>("RoomType", configuration);
            services.AddMongoCollection<Service>("Service", configuration);
            services.AddMongoCollection<Account>("Account", configuration);
            services.AddMongoCollection<Shift>("Shift", configuration);
            services.AddMongoCollection<ShiftDetail>("ShiftDetail", configuration);
            services.AddMongoCollection<Room>("Room", configuration);
            services.AddMongoCollection<ExtraService>("ExtraService", configuration);
            services.AddMongoCollection<Booking>("Booking", configuration);
            return services;
        }
    }
}
