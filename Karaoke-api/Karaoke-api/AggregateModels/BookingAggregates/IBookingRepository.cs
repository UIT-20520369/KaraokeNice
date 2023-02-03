using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.BookingAggregates
{
    public interface IBookingRepository: IRepository<Booking>
    {
        public Booking AddBooking (Booking booking);
        public void UpdateBooking (Booking booking);
        public void DeleteBooking (Booking booking);
    }
}
