using BookingServices.Models;
using BookingServices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        //IAirlineService airlineService;
        FlightDBContext db;
        public BookingController(FlightDBContext _db)
        {
            //airlineService = _airlineService;
            db = _db;
        }


        //[HttpPost("/api/v1.0/flight/booking")]
        [HttpPost("booking")]
        //[Authorize]
        public IActionResult Register([FromBody] BookingRegister rg)
        {

            try
            {
                UserBooking reg = new UserBooking();
                Random random = new Random();
                reg.Name = rg.Name;
                reg.EmailId = rg.EmailId;
                reg.Gender = rg.Gender;
                reg.Age = rg.Age;
                reg.Meal = rg.Meal;
                reg.SeatNo = rg.SeatNo;
                reg.Pnrno = random.Next(100, 500);
                reg.IsCancelled = rg.IsCancelled;
                reg.FlighNo = rg.FlighNo;
                db.UserBookings.Add(reg);
                db.SaveChanges();

                return Ok("Ticket Booked Successfully , Your PNR is "+reg.Pnrno);

            }
            catch(Exception ex)
            {
                return BadRequest();
            }


        }

        //[HttpDelete("/api/v1.0/flight/booking/cancel/{pnr}")]
        [HttpDelete("cancel/{pnr}")]
        public IActionResult CancelTicket(int pnr)
        {

            try
            {
                if (db.UserBookings.Any(x => x.Pnrno == pnr))
                {
                    var data = db.UserBookings.Where(x => x.Pnrno == pnr).FirstOrDefault();
                    db.UserBookings.Remove(data);
                    db.SaveChanges();
                    return Ok("Ticket Cancelled Successfully");

                }
                else
                {
                    return BadRequest();
                }
               

            }
            catch (Exception ex)
            {
                return BadRequest();
            }


        }



    }
}
