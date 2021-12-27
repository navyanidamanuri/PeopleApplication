using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApplication.Models.Repos;
using PeopleApplication.Models.Services;
using PeopleApplication.Models.ViewModels;
using PeopleApplication.Models;
using Microsoft.AspNetCore.Http;

namespace netcoremvcapp.Controllers
{
    public class PersonController : Controller
    {
        readonly IPeopleService peopleService;
        readonly ICityService cityService;
       public PersonController(IPeopleService peopleService, ICityService cityService)
        {
            this.peopleService = peopleService;
            this.cityService = cityService;
        }
        // GET: People
        public IActionResult AddNewPerson()
        {
            List<Cities> cityinfo = cityService.AllCities();
            ViewBag.ctinfo = cityinfo;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPerson(CreatePersonViewModel cpvm)
        {
            peopleService.Add(cpvm);
            List<Cities> cityinfo = cityService.AllCities();
            ViewBag.ctinfo = cityinfo;
            return View();
        }

        public IActionResult ShowAllPeople()
        {
            List<Person> lstPerson = peopleService.All();
            List<Cities> lstCity = cityService.AllCities();
            var getPeople = lstPerson.Join(lstCity,
                per => per.CityCode,
                cty=>cty.CityCode,(per,cty)=>new
                {
                    Pid = per.Pid,
                    Pname = per.Pname,
                    PhoneNumber = per.PhoneNumber,
                    CityName = cty.CityName
                });
            List<PeopleViewModel> people = new List<PeopleViewModel>();
            PeopleViewModel pvm = null;
            foreach(var x in getPeople)
            {
                pvm = new PeopleViewModel();
                pvm.Pid = x.Pid;
                pvm.Pname = x.Pname;
                pvm.PhoneNumber = x.PhoneNumber;
                pvm.CityName = x.CityName;
                people.Add(pvm);
            }
            return View(people);
        }


        public IActionResult PersonInfo(int id)
        {
            Person person = peopleService.FindById(id);
            Cities city = cityService.FindById(person.CityCode);
            PeopleViewModel pvm = new PeopleViewModel();
            pvm.Pid = person.Pid;
            pvm.Pname = person.Pname;
            pvm.PhoneNumber = person.PhoneNumber;
            pvm.CityName = city.CityName;
            return View(pvm);
        }

        public IActionResult Edit(int id)
        {
            List<Cities> cityinfo = cityService.AllCities();
            ViewBag.ctinfo = cityinfo;
            Person person = peopleService.FindById(id);
            CreatePersonViewModel cp = new CreatePersonViewModel();
            cp.Pid = person.Pid;
            cp.Pname = person.Pname;
            cp.PhoneNumber = person.PhoneNumber;
            cp.CityCode = person.CityCode;
            return View(cp);
        }
        [HttpPost]
        public IActionResult Edit(CreatePersonViewModel cpv)
        {
            bool chk = peopleService.Edit(cpv.Pid, cpv);
            if (chk == true)
                return RedirectToAction("ShowAllPeople");
            return View();
        }

        public IActionResult DeletePerson(int id)
        {
            bool chk = peopleService.Remove(id);
            if (chk == true)
                return RedirectToAction("ShowAllPeople");

            return View();
        }

        public IActionResult SearchPeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchPeople(IFormCollection f)
        {
            string str = f["txtSearch"].ToString();
            List<Person> all = peopleService.Search(str);
            return View(all);
        }
    }
}
