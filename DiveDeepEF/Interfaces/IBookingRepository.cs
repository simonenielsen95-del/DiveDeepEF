using DiveDeepEF.Models.Bookings;

namespace DiveDeepEF.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();
        Booking? GetById(int id);
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete(int id);

    }
}
