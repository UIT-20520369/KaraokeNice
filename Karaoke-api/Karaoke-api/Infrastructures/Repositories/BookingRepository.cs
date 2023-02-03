using Karaoke_api.AggregateModels.BookingAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Infrastructures.Repositories
{
    public class BookingRepository:IBookingRepository
    {
        IMongoCollection<Booking> _bookings;
        public BookingRepository(IMongoCollection<Booking> bookings)
        {
            _bookings = bookings;
        }
        public Booking AddBooking(Booking booking) {
         _bookings.InsertOne(booking);
            return booking;
        }
        public void UpdateBooking(Booking booking) {
         var bookDoc = _bookings.Find(b => b.Id ==booking.Id).FirstOrDefault();
            if (bookDoc != null)
            {
                bookDoc.Update(booking);
                _bookings.ReplaceOne(b => b.Id == booking.Id, bookDoc);
            }
            else
            {
                throw new Exception("Booking infor doesn't exist in database");
            }    
        }
        public void DeleteBooking(Booking booking)
        {
            _bookings.DeleteOne(b => b.Id==booking.Id);
        }

    }
}
