using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApplication.Models.ViewModels;

namespace PeopleApplication.Models
{
    public class PeopleContext:DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        { }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Cities> cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>()
                .HasOne<Country>(c => c.country)
                .WithMany(c => c.cityinfo)
                .HasForeignKey(s => s.CtryCode);

           modelBuilder.Entity<Person>()
                .HasOne<Cities>(p => p.city)
                .WithMany(c => c.person)
                .HasForeignKey(s => s.CityCode);
          
        }

        public DbSet<PeopleApplication.Models.ViewModels.CountryViewModel> CountryViewModel { get; set; }

        public DbSet<PeopleApplication.Models.ViewModels.CityViewModel> CityViewModel { get; set; }
       
        public DbSet<PeopleApplication.Models.ViewModels.GetCityViewModel> GetCityViewModel { get; set; }
        public DbSet<PeopleApplication.Models.ViewModels.CreatePersonViewModel> CreatePersonViewModel { get; set; }

        public DbSet<PeopleApplication.Models.ViewModels.PeopleViewModel> PeopleViewModel { get; set; }

    }
}
 