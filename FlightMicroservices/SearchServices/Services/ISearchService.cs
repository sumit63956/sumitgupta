using SearchServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchServices.Services
{
    public interface ISearchService
    {
        string Search(Schedule s);
    }
}
