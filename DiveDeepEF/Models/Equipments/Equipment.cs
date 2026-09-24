using System.ComponentModel.DataAnnotations;

namespace DiveDeepEF.Models.Equipments
{
    public abstract class Equipment
    {

        public int Id { get; set; }      
        public float PricePerDay { get; set; }
        public string Brand { get; set; }
       
    }
}
