using Karaoke_api.AggregateModels.RoleAggregates;
using MongoDB.Driver;

namespace Karaoke_api.Infrastructures.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        IMongoCollection<Role> _roles;
        public RoleRepository(IMongoCollection<Role> roles)
        {
            _roles = roles;
        }
        public Role AddRole(Role role) {
            _roles.InsertOne(role);
            return role;
        }
        public void UpdateRole(Role role) { 
            var roleDoc = _roles.Find(r=>r.Id== role.Id).FirstOrDefault();
            if(roleDoc ==null)
            {
                roleDoc.Update(role);
                _roles.ReplaceOne(r => r.Id == roleDoc.Id, roleDoc);
            }    
            else
            {
                throw new Exception("Role doesn't exist in database");
            }    
        }
        public void DeleteRole(Role role) { 
                _roles.DeleteOne(r => r.Id== role.Id);
        }
    }
}
