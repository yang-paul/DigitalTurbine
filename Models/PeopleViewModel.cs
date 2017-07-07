using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace DigitalTurbine.Models
{
    public class PeopleViewModel
    {
        public IPagedList<Person> People { get; set; }
        //public PagedList.IPagedList People { get; set; }
        public Races RaceList { get; set; }
    }
}