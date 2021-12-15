using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApplication.Models.Repos
{
    public class InMemoryPeopleRepo : IpeopleRepo
    {

        private static List<Person> lstPeople = new List<Person>();
        private static int idCounter;
        public Person Create(Person person)
        {
            lstPeople.Add(person);
            return person;
        }

        public bool Delete(Person person)
        {
            bool chk = false;
            foreach (Person p in lstPeople)
            {
                if (p == person)
                {
                    lstPeople.Remove(person);
                    chk = true;
                    break;
                }
            }
            return chk;
        }

        public List<Person> Read()
        {
            return lstPeople;
        }

        public Person Read(int id)
        {
            Person p1 = null;
            foreach (Person p in lstPeople)
            {
                if (p.Pid == id)
                {
                    p1 = new Person();
                    p1 = p;
                    break;
                }
            }
            return p1;
        }

        public bool Update(Person person)
        {
            bool chk = false;
            foreach (Person p in lstPeople)
            {
                if (p.Pid == person.Pid)
                {
                    p.Pname = person.Pname;
                    p.City = person.City;
                    p.PhoneNumber = person.PhoneNumber;
                    chk = true;
                    break;
                }
            }
            return chk;
        }
    }
}
