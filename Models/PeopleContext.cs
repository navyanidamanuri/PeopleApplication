using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApplication.Models
{
    public class PeopleContext:DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        { }
        public DbSet<Person> Peoples { get; set; }
         
       
    }
}
