using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.UserAggregates
{
    public interface IUserRepository : IRepository<User>
    {
        User AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
