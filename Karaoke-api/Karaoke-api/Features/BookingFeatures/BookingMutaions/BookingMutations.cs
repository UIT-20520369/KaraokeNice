using Karaoke_api.AggregateModels.BookingAggregates;
using Karaoke_api.AggregateModels.RoomTypeAggregates;
using Karaoke_api.AggregateModels.UserAggregates;

namespace Karaoke_api.Features.BookingFeatures.BookingMutaions
{
    public class BookingMutations
    {
        private readonly IBookingRepository bookingRepository;
        public BookingMutations(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        public string CreateBooking(string userId, string roomId,  string request,  DateTime createdAt, DateTime checkIn, DateTime checkOut, double deposit, double total)
        {
            var newBooking = new Booking(userId, roomId, request, createdAt, checkIn, checkOut, deposit, total);
            var res = bookingRepository.AddBooking(newBooking);
            return res.Id;
        }
        public string UpdateBooking(string? userId, string? roomId, string? request, DateTime? createdAt, DateTime? checkIn, DateTime? checkOut, double? deposit, double? total)
        {
            var newBooking = new Booking(userId, roomId, request, createdAt, checkIn, checkOut, deposit, total);
            bookingRepository.UpdateBooking(newBooking);
            return newBooking.Id;
        }
        public string DeleteBooking(string? userId, string? roomId, string? request, DateTime? createdAt, DateTime? checkIn, DateTime? checkOut, double? deposit, double? total)
        {
            var newBooking = new Booking(userId, roomId, request, createdAt, checkIn, checkOut, deposit, total);
            bookingRepository.DeleteBooking(newBooking);
            return newBooking.Id;
        }
    }
}
