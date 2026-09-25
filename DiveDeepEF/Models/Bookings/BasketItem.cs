using DiveDeepEF.Models.Equipments;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DiveDeepEF.Models.Bookings
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; } = null!; // Navigation property
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!; //Navigation property

    }
}
