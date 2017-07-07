using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalTurbine.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Races Race { get; set; }

        public override string ToString ()
        {
            return "My name is " + Name + " and I am " + Age + " years old";
        }

        public double Height
        {
            get {
                double height = 0;
                switch (Race)
                {
                    case Races.Asians:
                        height = (Age + 2) * 0.23 + 1.7;
                        break;
                    case Races.Jutes:
                        height = (Age * 1.6) / 2;
                        break;
                    default:
                        height = (Age * 0.45) + 1.5;
                        break;
                }
                return height;
            }
        }
    }
}