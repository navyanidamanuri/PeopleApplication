using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApplication.Models;
using PeopleApplication.Models.Repos;
using PeopleApplication.Models.ViewModels;
namespace PeopleApplication.Models.Services
{
    public class PeopleService:IPeopleService
    {
       readonly IPeopleRepo inMemoryPeopleRepo;
        public PeopleService(IPeopleRepo inMemoryPeopleRepo)
        {
            this.inMemoryPeopleRepo = inMemoryPeopleRepo;
        }
        public Person Add(CreatePersonViewModel person)
        {
            Person per1 = new Person();
            per1.Pid = person.Pid;
            per1.Pname = person.Pname;
            per1.PhoneNumber = person.PhoneNumber;
            per1.CityCode = person.CityCode;
            inMemoryPeopleRepo.Create(per1);
            return per1;
        }

        public List<Person> All()
        {
            return inMemoryPeopleRepo.Read();
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            Person per1 = new Person();
            per1.Pid = person.Pid;
            per1.Pname = person.Pname;
            per1.CityCode = person.CityCode;
            per1.PhoneNumber = person.PhoneNumber;
            bool chk = inMemoryPeopleRepo.Update(per1);
            return chk;
        }

        public Person FindById(int id)
        {
            return inMemoryPeopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Person DelPerson = inMemoryPeopleRepo.Read(id);
            bool chk = inMemoryPeopleRepo.Delete(DelPerson);
            return chk;
        }

        public List<Person> Search(string search)
        {
            List<Person> listAll = inMemoryPeopleRepo.Read();

            List<Person> listFilter = new List<Person>();

            foreach (Person p in listAll)
            {
                if (p.Pname.Equals(search) )
                {
                    listFilter.Add(p);
                }
            }
            return listFilter;
        }
    }

    }