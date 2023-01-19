using Karaoke_api.AggregateModels.RoleAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Features.RoleFeatures.RoleQueries
{
    [ExtendObjectType(name: "Query")]
    public class RoleQueries
    {
        [UseFiltering]
        [UseSorting]
        public IExecutable<Role> GetRoles([Service] IMongoCollection<Role> roles)
        {
            return roles.AsExecutable();
        }
    }
}
