using Karaoke_api.AggregateModels.UserAggregates;
using Karaoke_api.AggregateModels.RoleAggregates;
using Karaoke_api.AggregateModels.EmployeeAggregates;
using Karaoke_api.AggregateModels.RoomTypeAggregates;
using Karaoke_api.AggregateModels.ServiceAggregates;
using Karaoke_api.AggregateModels.AccountAggregates;
using Karaoke_api.Infrastructures.Repositories;
using Karaoke_api.Infrastructures.BsonMapping;
namespace Karaoke_api.Infrastructures
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            BsonMapping.BsonMapping.CreateBsonMapping();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();
            services.AddSingleton<IServiceRepository, ServiceRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
