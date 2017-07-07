using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalTurbine.Models
{
    public class PeopleSummary
    {
        public Races Race { get; set; }
        public int NumOfPeople { get; set; }
        public double AverageAge { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }
}