using Karaoke_api.AggregateModels.Seedwork;
using Karaoke_api.AggregateModels.ShiftAggregates;
using Karaoke_api.AggregateModels.ShiftDetailAggregates;
using Karaoke_api.AggregateModels.UserAggregates;
using System.Reflection;

namespace Karaoke_api.AggregateModels.ShiftDetailAggregates
{
    public class ShiftDetail: IAggregateRoot
    {
        public string Id { get; set; }
        public string ShiftId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? WorkDay { get; set; }
        public User? Employee { get; set; }
        public Shift? Shifting { get; set; }
        public ShiftDetail() {
        }
        public ShiftDetail(string shiftId, string employeeId, DateTime? workDay, string id = null)
        {
            Id = id;
            ShiftId = shiftId;
            EmployeeId = employeeId;
            WorkDay = workDay;
        }
        public void Update(ShiftDetail shiftDetail)
        {
            foreach (var item in shiftDetail.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(shiftDetail).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(shiftDetail).ToString() == "0") continue;
                if (item.GetValue(shiftDetail) == null) continue;
                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(shiftDetail));
            }
        }
    }
}
