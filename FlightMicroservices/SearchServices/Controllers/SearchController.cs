using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchServices.Models;
using SearchServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {


        FlightDBContext db;
        public SearchController(FlightDBContext _db)
        {
            db = _db;
        }
        
        [HttpGet("searchrec")]
        public IActionResult SearchRec([FromBody]SearchRegister ss)
        {
            try
            {
                if (db.Schedules.Any(x => x.FrmPlace == ss.FrmPlace && x.ToPlace == ss.ToPlace && x.StrtDate == ss.StrtDate && x.EndDate == ss.EndDate))
                {
                    var data = db.Schedules.Where(x => x.FrmPlace == ss.FrmPlace && x.ToPlace == ss.ToPlace && x.StrtDate == ss.StrtDate && x.EndDate == ss.EndDate).FirstOrDefault();
                   
                        return Ok(data);

                   
                   
                }
                else
                {
                    return BadRequest("No Flights found");
                }

            }
            catch(Exception e)
            {
                return BadRequest();
            }

        }

        [HttpGet("searchbypnr/{pnr}")]
        public IActionResult SearchByPNR(int pnr)
        {
            if (db.UserBookings.Any(x => x.Pnrno == pnr ))
            {
                var data = db.UserBookings.Where(x => x.Pnrno == pnr ).FirstOrDefault();
                return Ok(data);

            }
            return BadRequest("No Record found");
        }


        [HttpGet("searchbyemail/{emailId}")]
        public IActionResult SearchByEmail(string emailId)
        {
            if (db.UserBookings.Any(x => x.EmailId == emailId))
            {
                var data = db.UserBookings.Where(x => x.EmailId == emailId).FirstOrDefault();
                return Ok(data);

            }
            return BadRequest("No Record found");
        }



    }
}
