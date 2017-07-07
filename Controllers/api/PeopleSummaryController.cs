using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DigitalTurbine.Controllers;
using DigitalTurbine.Models;

namespace DigitalTurbine.Controllers.api
{
    public class PeopleSummaryController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var people = PeopleController.GetPeople(id, false);
            if (people == null)
                return NotFound();

            PeopleSummary summ = new PeopleSummary
            {
                Race = (Races)id,
                NumOfPeople = people.Count(),
                AverageAge = Math.Round(people.Average(p => p.Age), 2),
                MinAge = people.Min(p => p.Age),
                MaxAge = people.Max(p => p.Age)
            };
            return Ok(summ);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}