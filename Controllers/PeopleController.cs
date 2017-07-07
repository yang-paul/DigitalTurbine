using DigitalTurbine.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace DigitalTurbine.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index(string raceList, int pageNo = 1)
        {
            int selectedRace = string.IsNullOrEmpty(raceList) ? 0 : Convert.ToInt32(raceList);
            int pageSize = 20;
            var model = new PeopleViewModel
            {
                People = GetPeople(selectedRace, true).ToPagedList(pageNo, pageSize)
            };
            ViewBag.raceList = selectedRace;
            return View(model);
        }

        public ActionResult IncreasePeopleAge()
        {
            IncreaseAllPeopleAge();

            return RedirectToAction("Index");
        }

        public static IEnumerable<Person> GetPeople(int? raceId, bool isEvenAge)
        {
            List<Person> people = (List<Person>)MemoryCache.Default["InitPeople"];
            if (people == null)
            {
                people = InitPeople();
                MemoryCache.Default["InitPeople"] = people;
            }

            if (raceId > 0)
            {
                people = people
                    .Where(p => p.Race == (Races)raceId && p.Age % 2 == 0)
                    .OrderBy(p => p.Age)
                    .ToList();
            }
            return people;
        }

        private void IncreaseAllPeopleAge()
        {
            var people = GetPeople(0, false);
            foreach (Person p in people)
            {
                p.Age++;
            }
            MemoryCache.Default["InitPeople"] = people;
        }

        public static List<Person> InitPeople()
        {
            List<Person> people = new List<Person>();
            Array races = Enum.GetValues(typeof(Races));

            Random rnd = new Random();
            for (int i = 1; i <= 10000; i++)
            {
                people.Add(new Person()
                {
                    Name = "Person #" + i.ToString(),
                    Age = rnd.Next(1, 99),
                    Race = (Races)races.GetValue(rnd.Next(races.Length))
                });
            }
            return people;
        }


    }
}