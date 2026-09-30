using DiveDeepEF.Models.Bookings;
using Microsoft.AspNetCore.Identity;

namespace DiveDeepEF.Data;


public class ApplicationUser : IdentityUser
    {
        public ICollection<Booking>? Bookings { get; set; }

        // np
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
