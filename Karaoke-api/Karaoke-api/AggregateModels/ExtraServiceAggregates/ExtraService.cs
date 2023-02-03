using Karaoke_api.AggregateModels.Seedwork;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Reflection;

namespace Karaoke_api.AggregateModels.ExtraServiceAggregates
{
    public class ExtraService:IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Unit { get; set; }
        public ExtraService( string name, double? price, string unit,string id=null)
        {
            Id = id;
            Name = name;
            Price = price;
            Unit = unit;
        }
        public ExtraService() { }
        public void Update(ExtraService extraService)
        {
            foreach (var item in extraService.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(extraService).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(extraService).ToString() == "0") continue;
                if (item.GetValue(extraService) == null) continue;
                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(extraService));
            }
        }
    }
}
