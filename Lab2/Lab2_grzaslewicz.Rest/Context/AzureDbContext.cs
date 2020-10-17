using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_grzaslewicz.Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2_grzaslewicz.Rest.Context
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options) : base(options)
        {
        }

        public AzureDbContext()
        {
        }

        public DbSet<Person> People { get; set; }
    }
}