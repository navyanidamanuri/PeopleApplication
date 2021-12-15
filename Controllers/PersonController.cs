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
        IPeopleService people;
       public PersonController(IPeopleService people)
        {
            this.people = people;
        }
        // GET: People
        public IActionResult AddNewPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPerson(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                Person per = people.Add(person);
                if (per != null)
                    ViewBag.info = "Person Details are Added...";
                else
                    ViewBag.info = "Person Details are Not Added...";
            }
            return View();
        }

        public IActionResult ShowAllPeople()
        {
            List<Person> peopleinfo = people.All();
            List<PeopleViewModel> viewpeopleList = new List<PeopleViewModel>();
            PeopleViewModel pv = null;
            if (peopleinfo.Count != 0)
            {
                foreach (Person p in peopleinfo)
                {
                    pv = new PeopleViewModel();
                    pv.Pid = p.Pid;
                    pv.Pname = p.Pname;
                    pv.PhoneNumber = p.PhoneNumber;
                    pv.City = p.City;
                    viewpeopleList.Add(pv);
                }
            }
            return View(viewpeopleList);
        }


        public IActionResult PersonInfo(int id)
        {
            Person person = people.FindById(id);
            CreatePersonViewModel cp = new CreatePersonViewModel();
            cp.Pid = person.Pid;
            cp.Pname = person.Pname;
            cp.PhoneNumber = person.PhoneNumber;
            cp.City = person.City;
            return View(cp);
        }

        public IActionResult Edit(int id)
        {
            Person person = people.FindById(id);
            CreatePersonViewModel cp = new CreatePersonViewModel();
            cp.Pid = person.Pid;
            cp.Pname = person.Pname;
            cp.PhoneNumber = person.PhoneNumber;
            cp.City = person.City;
            return View(cp);
        }
        [HttpPost]
        public IActionResult Edit(CreatePersonViewModel cpv)
        {
            bool chk = people.Edit(cpv.Pid, cpv);
            if (chk == true)
                return RedirectToAction("ShowAllPeople");
            return View();
        }

        public IActionResult DeletePerson(int id)
        {
            bool chk = people.Remove(id);
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
            List<Person> all = people.Search(str);
            return View(all);
        }
    }
}
