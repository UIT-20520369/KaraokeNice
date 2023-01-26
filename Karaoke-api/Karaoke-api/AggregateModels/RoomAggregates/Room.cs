using Karaoke_api.AggregateModels.RoomTypeAggregates;
using Karaoke_api.AggregateModels.Seedwork;
using System.Reflection;

namespace Karaoke_api.AggregateModels.RoomAggregates
{
    public class Room :IAggregateRoot
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string TypeId { get; set; }
        public RoomType? RoomType { get; set; }

        public Room( string number, string typeId,string id=null)
        {
            Id = id;
            Number = number;
            TypeId = typeId;
        }
        public Room() { }
        public void Update(Room room)
        {
            foreach (var item in room.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(room).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(room).ToString() == "0") continue;
                if (item.GetValue(room) == null) continue;
                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(room));
            }
        }
    }
}
