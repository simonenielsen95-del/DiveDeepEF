using DiveDeepEF.Data;
using DiveDeepEF.Interfaces;
using DiveDeepEF.Models.Bookings;
using DiveDeepEF.Models.Equipments;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepEF.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DiveDeepEFContext _context;

        public BookingRepository(DiveDeepEFContext context)
        {
            _context = context;
        }

        public  List<Booking> GetAll()
        {
            return _context.Bookings
            .Include(b => b.BasketItems)
            .ThenInclude(bi => bi.Equipment)
            .ToList();
        }

        public Booking? GetById(int id)
        {
            return _context.Bookings
            .Include(b => b.BasketItems)
            .ThenInclude(bi => bi.Equipment)
            .FirstOrDefault(b => b.Id == id);
        }

        public void Add(Booking booking)
        {
            if (booking == null) return;
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Booking? booking = GetById(id);

            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }

        public void Update(Booking booking)
        {
            Booking? target = GetById(booking.Id);

            if (target != null)
            {
                target.CostumerName = booking.CostumerName;
                target.CostumerEmail = booking.CostumerEmail;
                target.StartDate = booking.StartDate;
                target.EndDate = booking.EndDate;

                _context.SaveChanges();
            }
        }

        public void AddBasketItem(int bookingId, int equipmentId)
        {
            var basketItem = new BasketItem
            {
                BookingId = bookingId,
                EquipmentId = equipmentId,
            };

            _context.BasketItems.Add(basketItem);
            _context.SaveChanges();
        }

        public void RemoveBasketItem(int basketItemId)
        {
            BasketItem? basketItem =
                _context.BasketItems.Find(basketItemId);

            if (basketItem != null)
            {
                _context.BasketItems.Remove(basketItem);
                _context.SaveChanges();
            }
        }

    }
}
