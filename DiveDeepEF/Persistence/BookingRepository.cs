using DiveDeepEF.Models.Bookings;
using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class BookingRepository
    {
        private static List<Booking> bookings = new List<Booking>();

        public static List<Booking> GetAll()
        {
            return bookings;
        }
        public static void Add(Booking booking)
        {
            if (booking == null) return;
            booking.Id = bookings.Any() ? bookings.Max(x => x.Id) + 1 : 1;
            bookings.Add(booking);
        }

    }
}
