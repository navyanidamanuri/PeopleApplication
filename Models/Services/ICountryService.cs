using PeopleApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApplication.Models.Services
{
    public interface ICountryService
    {
        Country AddCountry(CountryViewModel countryViewModel);
        List<Country> AllCountries();
        Country FindById(int id);
        bool Edit(int id, CountryViewModel cvm);
        bool Remove(int id);


    }
}
