using Karaoke_api.AggregateModels.Seedwork;
using System.Reflection;

namespace Karaoke_api.AggregateModels.AccountAggregates
{
    public class Account: IAggregateRoot
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Account ( string username, string password, string id=null)
        {
            Id = id;
            Username = username;
            Password = password;
        }
        public Account() { }
        public void Update(Account account)
        {
            foreach (var item in account.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(account).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(account).ToString() == "0") continue;
                if (item.GetValue(account) == null) continue;

                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(account));
            }
        }
    }
}
