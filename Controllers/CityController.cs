using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApplication.Models;
using PeopleApplication.Models.Services;
using PeopleApplication.Models.ViewModels;

namespace PeopleApplication.Controllers
{

    public class CityController : Controller
    {

        readonly ICityService ics;
        readonly ICountryService icrs;
        public CityController(ICityService ics, ICountryService icrs)
        {
            this.ics = ics;
            this.icrs = icrs;
        }
        public IActionResult ViewCities()
        {
            List<Country> ctryList = icrs.AllCountries();
            List<Cities> cityList = ics.AllCities();
            

            var getCities = cityList.Join(ctryList,
                city => city.CtryCode,
                ctry => ctry.CrtyCode, (city, ctry) => new {
                    CityCode = city.CityCode,
                    CityName = city.CityName,
                    CtryName = ctry.CrtyName
                });

            List<GetCityViewModel> listAll = new List<GetCityViewModel>();
            GetCityViewModel gvm = null;
            foreach (var n in getCities)
            {
                gvm = new GetCityViewModel();
                gvm.CityCode = n.CityCode;
                gvm.CityName = n.CityName;
                gvm.CtryName = n.CtryName;
                listAll.Add(gvm);
            }
            return View(listAll);
        }
        public IActionResult AddCity()
        {
            List<Country> CountryInfo = icrs.AllCountries();
            ViewBag.cinfo = CountryInfo;
            return View();
        }
        [HttpPost]
        public IActionResult AddCity(CityViewModel cty)
        {
            Cities ct = ics.AddCity(cty);
            List<Country> CountryInfo = icrs.AllCountries();
            ViewBag.cinfo = CountryInfo;
            return View();
        }
    }
}
