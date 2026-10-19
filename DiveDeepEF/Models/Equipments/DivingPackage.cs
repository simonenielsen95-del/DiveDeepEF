using System.ComponentModel.DataAnnotations;
using DiveDeepEF.Models.Equipments;

namespace Dive_Deep.Models.Equipment
{
    public class DivingPackage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        // Fremmednøgler
        public int? BcdId { get; set; }
        public int? SuitId { get; set; }
        public int? RegulatorId { get; set; }
        public int? TankId { get; set; }
        public int? FinsId { get; set; }
        public int? MaskId { get; set; }


        // Navigation properties
        public BCD? Bcd { get; set; }
        public Suit? Suit { get; set; }
        public RegulatorSet? Regulator { get; set; }
        public Tank? Tank { get; set; }
        public Fins? Fins { get; set; }
        public Mask? Mask { get; set; }


        public decimal PricePerDay { get; set; }

      
    }
}