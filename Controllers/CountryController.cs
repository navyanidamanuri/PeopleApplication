using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApplication.Models.Services;
using PeopleApplication.Models;
using PeopleApplication.Models.ViewModels;

namespace PeopleApplication.Controllers
{
    public class CountryController : Controller
    {
        readonly ICountryService countryService;
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        public IActionResult ShowAll()
        {
            return View(countryService.AllCountries());
        }
        public IActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCountry(CountryViewModel cvm)
        {
            countryService.AddCountry(cvm);
            ViewBag.info = "Country Added...";
            return RedirectToAction("ShowAll");
        }

    }
}
 