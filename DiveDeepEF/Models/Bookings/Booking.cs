namespace DiveDeepEF.Models.Bookings
{
    public class Booking
    {
        public int Id { get; set; }
        public string CostumerName { get; set; }
        public string CostumerEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
