using Karaoke_api.AggregateModels.UserAggregates;
using Karaoke_api.Infrastructures.Repositories;
namespace Karaoke_api.Features.UserFeatures.UserMutations
{
    [ExtendObjectType(name: "Mutation")]
    public class UserMutations
    {
        private readonly IUserRepository _userRepository;
        public UserMutations(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string CreateUser(string name, string phone, UserAddress address,string gender)
        {
            var user = new User(name, phone, gender, address);
            var tempUser = _userRepository.AddUser(user);
            return tempUser.Id;
        }
        public string UpdateUser(string id,string? name, string? phone, UserAddress? address,string? gender)
        {
            var user=new User( name, phone,gender, address,id);
            _userRepository.UpdateUser(user);
            return user.Id;
        }
        public string DeleteUser(string id, string? name, string? phone, UserAddress? address, string? gender)
        {
            var user = new User(name, phone, gender, address,id);
            _userRepository.DeleteUser(user);
            return user.Id;
        }
    }
}
