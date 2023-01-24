using Karaoke_api.AggregateModels.Seedwork;
using System.Reflection;

namespace Karaoke_api.AggregateModels.RoomTypeAggregates
{
    public class RoomType: IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Gallery { get; set; }
        public int Guests { get; set; }
        public double Price { get; set; }
        public string[] Services { get; set; }
        public string Thumnail { get; set; }
        public RoomType(string id, string name, string description, string[] gallery, int guests, double price, string[] services, string thumnail)
        {
            Id = id;
            Name = name;
            Description = description;
            Gallery = gallery;
            Guests = guests;
            Price = price;
            Services = services;
            Thumnail = thumnail;
        }
        public RoomType() { }
        public void Update(RoomType roomType)
        {
            foreach (var item in roomType.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(roomType).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(roomType).ToString() == "0") continue;
                if (item.GetValue(roomType) == null) continue;
                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(roomType));
            }
        }
    }
}
