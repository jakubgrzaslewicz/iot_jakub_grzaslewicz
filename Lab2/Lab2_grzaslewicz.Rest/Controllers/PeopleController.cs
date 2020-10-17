using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Lab2_grzaslewicz.Rest.Context;
using Lab2_grzaslewicz.Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lab2_grzaslewicz.Rest.Controllers
{
    [ApiController]
    [Route("/people")]
    public class PeopleController : ControllerBase
    {
        private AzureDbContext azureDbContext;

        private readonly ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger, AzureDbContext azureDbContext)
        {
            _logger = logger;
            this.azureDbContext = azureDbContext;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var data = azureDbContext.People;
            return data.AsEnumerable();
        }

        [HttpPost]
        public Person Add([FromBody] Person person)
        {
            var newPerson = person;
            var a = azureDbContext.People.Add(person);
            azureDbContext.SaveChanges();
            return a.Entity;
        }

        [HttpPut]
        public Person Update([FromBody] Person person)
        {
            var newPerson = person;
            var a = azureDbContext.People.Update(newPerson);
            azureDbContext.SaveChanges();
            return a.Entity;
        }

        [HttpGet]
        [Route("{id}")]
        public Person GetById([FromRoute] int id)
        {
            return azureDbContext.People.First(x => x.PersonId == id);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete([FromRoute] int id)
        {
            var toRemove = azureDbContext.People.First(x => x.PersonId == id);
            var result = azureDbContext.People.Remove(toRemove);
            azureDbContext.SaveChanges();
            return true;
        }
    }
}