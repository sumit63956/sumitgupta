using System;
using System.Collections.Generic;

#nullable disable

namespace BookingServices.Models
{
    public partial class AirlineReg
    {
        public AirlineReg()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int AirlineId { get; set; }
        public string Name { get; set; }
        public string UpdateLogo { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAdd { get; set; }
        public string Available { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
