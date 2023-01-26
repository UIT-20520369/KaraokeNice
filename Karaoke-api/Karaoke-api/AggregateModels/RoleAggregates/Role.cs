using System.Reflection;
using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.RoleAggregates
{
    public class Role :IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Role () { }
        public Role ( string name, string code, string id=null)
        {
            Id = id; Name = name;
            Code = code;
        }
        public void Update(Role role)
        {
            foreach (var item in role.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(role).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(role).ToString() == "0") continue;
                if (item.GetValue(role) == null) continue;

                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(role));
            }
        }
    }
}
