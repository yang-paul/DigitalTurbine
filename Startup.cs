using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using DigitalTurbine.Models;
using System.Collections.Generic;
using System.Runtime.Caching;

[assembly: OwinStartup(typeof(DigitalTurbine.Startup))]

namespace DigitalTurbine
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var people = DigitalTurbine.Controllers.PeopleController.InitPeople();

            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddDays(1);
            MemoryCache.Default["InitPeople"] = people;
        }

    }
}
