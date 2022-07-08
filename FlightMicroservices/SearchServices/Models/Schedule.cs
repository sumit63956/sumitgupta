using System;
using System.Collections.Generic;

#nullable disable

namespace SearchServices.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            UserBookings = new HashSet<UserBooking>();
        }

        public string FlighNo { get; set; }
        public int AirlineId { get; set; }
        public string FrmPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StrtDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ScheduleId { get; set; }
        public string Instrument { get; set; }
        public int? NoOfSeats { get; set; }
        public int? NoOfBcseats { get; set; }
        public int? NoOfNbcseats { get; set; }
        public int? TicketCost { get; set; }
        public int? NoOfRows { get; set; }
        public string Meal { get; set; }
        public string Trip { get; set; }
        public int? ToPlaceId { get; set; }
        public int? FromPlaceId { get; set; }

        public virtual AirlineReg Airline { get; set; }
        public virtual ScheduleDay ScheduleNavigation { get; set; }
        public virtual ICollection<UserBooking> UserBookings { get; set; }
    }
}
