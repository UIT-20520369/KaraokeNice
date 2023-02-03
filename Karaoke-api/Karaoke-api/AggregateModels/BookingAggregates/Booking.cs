using Karaoke_api.AggregateModels.RoomTypeAggregates;
using Karaoke_api.AggregateModels.Seedwork;
using Karaoke_api.AggregateModels.ShiftDetailAggregates;
using Karaoke_api.AggregateModels.UserAggregates;
using System.Reflection;

namespace Karaoke_api.AggregateModels.BookingAggregates
{
    public class Booking: IAggregateRoot
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User? Customer { get; set; }
        public string RoomId { get; set; }
        public RoomType RoomType { get; set; }
        public string Status { get; set; }
        public string Request { get; set; }
        public string[] ExtraService { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public double? Deposit { get; set; }
        public double? Total { get; set; }
        public Booking(string userId, string roomId, string request, DateTime? createdAt, DateTime? checkIn, DateTime? checkOut, double? deposit, double? total, string id = null)
        {
            Id = id;
            UserId = userId;
            RoomId = roomId;
            Status = "Đã đặt phòng";
            Request = request;
            CreatedAt = createdAt;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Deposit = deposit;
            Total = total;
        }
        public Booking() { }

        public void Update(Booking booking)
        {
            foreach (var item in booking.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(booking).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(booking).ToString() == "0") continue;
                if (item.GetValue(booking) == null) continue;
                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(booking));
            }
        }

    }
}
