using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiveDeepEF.Data;
using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Models.Bookings
{
    public class Booking
    {
        public int Id { get; set; }
        public string CostumerName { get; set; }
        public string CostumerEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public byte[]? RowVersion { get; set; }

        // til identity-forhold
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public List<BasketItem> BasketItems { get; set; } = new();

        //kan laves med fluent API i stedet for [NotMapped] :
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Booking>()
        //.Ignore(b => b.TotalPrice);

        //modelBuilder.Entity<Booking>()
        //.Ignore(b => b.NumberOfDays);
        //}
        [NotMapped]
        public int NumberOfDays =>
            (EndDate.Date - StartDate.Date).Days + 1;

        [NotMapped]
        public float TotalPrice =>
            BasketItems.Sum(item =>
                
                item.Equipment.PricePerDay *
                NumberOfDays);

    }
}
