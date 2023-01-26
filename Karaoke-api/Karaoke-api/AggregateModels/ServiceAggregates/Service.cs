using Karaoke_api.AggregateModels.RoomTypeAggregates;
using Karaoke_api.AggregateModels.Seedwork;
using System.Reflection;

namespace Karaoke_api.AggregateModels.ServiceAggregates
{
    public class Service: IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        public string Thumbnail { get; set; }
        public Service( string name, string type, string thumbnail, string id=null)
        {
            Id = id;
            Name = name;
            Type = type;
            Thumbnail = thumbnail;
        }
        public Service() { }
        public void Update(Service service)
        {
            foreach (var item in service.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(service).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(service).ToString() == "0") continue;
                if (item.GetValue(service) == null) continue;
                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(service));
            }
        }
    }
}
