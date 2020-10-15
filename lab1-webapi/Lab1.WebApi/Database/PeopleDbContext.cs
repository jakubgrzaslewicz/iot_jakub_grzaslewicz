using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Lab1.WebApi.Database
{
    public class PeopleDbContext:DbContext
   
    {
        public PeopleDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> person { get; set; }
    }
}
