using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.UserAggregates
{
    public class User :IAggregateRoot
    {

        public string Id { get;private set; }
        public string Name { get;private set; }
        public string Phone { get; private set; }
        public string Gender { get; private set; }
        public UserAddress Address { get; private set; }

        public User() { }
        public User( string id, string name, string phone, string gender, UserAddress address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Gender = gender;
            Address = address;
        }
        public void Update(User user)
        {
            foreach (var item in user.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(user).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(user).ToString() == "0") continue;
                if (item.GetValue(user) == null) continue;

                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(user));
            }
        }
    }
}
