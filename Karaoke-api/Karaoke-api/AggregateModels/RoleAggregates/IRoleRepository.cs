using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.RoleAggregates
{
    public interface IRoleRepository :IRepository<Role>
    {
        public Role AddRole(Role role);
        public void UpdateRole(Role role);
        public void DeleteRole(Role role);

    }
}
