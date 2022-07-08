using System;
using System.Collections.Generic;

#nullable disable

namespace BookingServices.Models
{
    public partial class ScheduleDay
    {
        public ScheduleDay()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int ScheduleId { get; set; }
        public string Sunday { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
