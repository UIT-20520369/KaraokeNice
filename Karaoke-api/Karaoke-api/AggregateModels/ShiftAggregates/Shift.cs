using Karaoke_api.AggregateModels.Seedwork;
using Karaoke_api.AggregateModels.ServiceAggregates;
using System.Reflection;

namespace Karaoke_api.AggregateModels.ShiftAggregates
{
    public class Shift:IAggregateRoot
    {
        public string Id { get; set; }
        public string ShiftName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Shift( string shiftName, DateTime? startTime, DateTime? endTime,string id=null)
        {
            Id = id;
            ShiftName = shiftName;
            StartTime = startTime;
            EndTime = endTime;
        }
        public Shift() {
            StartTime= DateTime.UtcNow; EndTime= DateTime.UtcNow;
        }
        public void Update(Shift shift)
        {
            foreach (var item in shift.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(shift).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(shift).ToString() == "0") continue;
                if (item.GetValue(shift) == null) continue;
                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(shift));
            }
        }
    }
}
