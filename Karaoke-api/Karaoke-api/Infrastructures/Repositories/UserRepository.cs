using Karaoke_api.AggregateModels.UserAggregates;
using MongoDB.Driver;

namespace Karaoke_api.Infrastructures.Repositories
{
    public class UserRepository:IUserRepository
    {
        IMongoCollection<User> _users;
        public UserRepository(IMongoCollection<User> collection) 
        {
            _users = collection;
        }
        public User AddUser(User user) { 
            _users.InsertOne(user);
            return user;
        }
        public void UpdateUser(User user) { 
            var userDocument = _users.Find(u => u.Id == user.Id).FirstOrDefault();
            if (userDocument != null)
            {
                userDocument.Update(user);
                _users.ReplaceOne(u => u.Id == user.Id, userDocument);
            }
            else
            {
                throw new Exception("This user doesn't exists in database!");
            }    
        }
        public void DeleteUser(User user) {
            _users.DeleteOne(u=>u.Id == user.Id);        
        }
    }
}
