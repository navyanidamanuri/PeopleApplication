using PeopleApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApplication.Models;
using PeopleApplication.Models.Repos;


namespace PeopleApplication.Models.Services
{
    public class CountryService : ICountryService
    {
        readonly ICountryRepo countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            this.countryRepo = countryRepo;
        }

        public Country AddCountry(CountryViewModel countryViewModel)
        {
            Country country = new Country();
            country.CrtyCode = countryViewModel.CrtyCode;
            country.CrtyName = countryViewModel.CrtyName;
            countryRepo.Create(country);
            return country;
        }

        public List<Country> AllCountries()
        {
            return countryRepo.Read();
        }

        public bool Edit(int id, CountryViewModel cvm)
        {
            Country country = countryRepo.Read(id);
            country.CrtyName = cvm.CrtyName;
            bool chk = false;
            chk = countryRepo.update(country);
            return chk;
 
        }           

        public Country FindById(int id)
        {
            return countryRepo.Read(id);
        }

        public bool Remove(int id)
        {
            bool chk = false;
            chk = countryRepo.Delete(countryRepo.Read(id));
            return chk;
        }
    }
}
