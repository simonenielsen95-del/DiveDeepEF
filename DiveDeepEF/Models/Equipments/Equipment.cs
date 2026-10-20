namespace DiveDeepEF.Models.Equipments;

public abstract class Equipment
{

    public int Id { get; set; }
    
    public decimal PricePerDay { get; set; }
    public string Brand { get; set; }

}
