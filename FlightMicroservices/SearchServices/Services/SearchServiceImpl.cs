using SearchServices.Models;
using SearchServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchServices.Services
{
    public class SearchServiceImpl
    {
        FlightDBContext db;
        public SearchServiceImpl(FlightDBContext _db)
        {
            db = _db;
        }
        public string Search(SearchRegister ss)
        {
            if (db.Schedules.Any(x => x.FrmPlace == ss.FrmPlace && x.ToPlace == ss.ToPlace && x.StrtDate == ss.StrtDate && x.EndDate == ss.EndDate))
            {
                var data = db.Schedules.Where(x => x.FrmPlace == ss.FrmPlace && x.ToPlace == ss.ToPlace && x.StrtDate == ss.StrtDate && x.EndDate == ss.EndDate).FirstOrDefault();
                return data.ToString();
            }
            return "No record Found";
        }

       
    }
}
