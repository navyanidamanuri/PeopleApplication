using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApplication.Models.ViewModels;
namespace PeopleApplication.Models.Services
{
     public interface ICityService
    {
        Cities AddCity(CityViewModel cityViewModel);
        List<Cities> AllCities();
        Cities FindById(int id);
        bool Edit(int id, CityViewModel cvm);
        bool Remove(int id);
    }
}
