using DiveDeepEF.Models.Equipments;
using Dive_Deep.Models.Equipment;

namespace DiveDeepEF.Models.Bookings
{
    public class BasketItem
    {
        public int Id { get; set; }

        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;

        public int? EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

        public int? DivingPackageId { get; set; }
        public DivingPackage? DivingPackage { get; set; }

        public int Days { get; set; } = 1;
        public string? SelectedSize { get; set; } 
        public string? SuitGender { get; set; }
    }
}