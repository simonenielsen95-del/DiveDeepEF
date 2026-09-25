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

        public static Booking? GetById(int id) => bookings.FirstOrDefault(x => x.Id == id);

        public static void Add(Booking booking)
        {
            if (booking == null) return;
            booking.Id = bookings.Any() ? bookings.Max(x => x.Id) + 1 : 1;
            bookings.Add(booking);
        }

        public static void Delete(int id)
        {
            bookings.RemoveAll(x => x.Id == id);
        }

        public static void Update(int id, Booking booking)
        {
            var target = GetById(id);
            if (target != null && booking != null)
            {
                target.CostumerName = booking.CostumerName;
                target.CostumerEmail = booking.CostumerEmail;
                target.StartDate = booking.StartDate;
                target.EndDate = booking.EndDate;
                target.BasketItems = booking.BasketItems;
            }
        }
    }
}
