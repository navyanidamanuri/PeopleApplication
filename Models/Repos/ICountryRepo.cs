using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApplication.Models.Repos
{
    public interface ICountryRepo
    {
        Country Create(Country country);
         List<Country> Read();
        Country Read(int id);
        bool update(Country country);
        bool Delete(Country country); 

    }
}
