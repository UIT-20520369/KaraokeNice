using Karaoke_api.AggregateModels.RoleAggregates;
using Karaoke_api.Infrastructures.Repositories;
namespace Karaoke_api.Features.RoleFeatures.RoleMutations
{

    [ExtendObjectType(name: "Mutation")]
    public class RoleMutations
    {
        private readonly IRoleRepository roleRepository;
        public RoleMutations(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public string CreateRole(string name, string code)
        {
            var role =new Role(name, code);
            var temp = roleRepository.AddRole(role);
            return temp.Id;
        }
        public string UpdateRole(string id,string? name, string? code)
        {
            var role =new Role(name, code,id);
            roleRepository.UpdateRole(role);
            return role.Id;
        }
        public string DeleteRole(string id, string? name, string? code)
        {
            var role = new Role(name, code, id);
            roleRepository.DeleteRole(role);
            return role.Id;
        }
    }
}
