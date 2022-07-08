using System;
using System.Collections.Generic;

#nullable disable

namespace BookingServices.Models
{
    public partial class UserBooking
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Meal { get; set; }
        public int? SeatNo { get; set; }
        public long? Pnrno { get; set; }
        public string IsCancelled { get; set; }
        public string FlighNo { get; set; }

        public virtual Schedule FlighNoNavigation { get; set; }
    }
}
