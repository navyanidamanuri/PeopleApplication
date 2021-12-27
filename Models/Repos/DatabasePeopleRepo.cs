using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApplication.Models.Repos
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        readonly PeopleContext dbCon;
       
       public DatabasePeopleRepo(PeopleContext dbCon)
        {
            this.dbCon = dbCon;
        }
        public Person Create(Person person)
        {
            dbCon.Peoples.Add(person);
            dbCon.SaveChanges();
            return person;
        }
         
        public bool Delete(Person person)
        {
            bool chk = false;
            Person prsn = dbCon.Peoples.Find(person.Pid);
            if(prsn!=null)
            {
                dbCon.Peoples.Remove(person);
                dbCon.SaveChanges();
                chk = true;
            }
            return chk;

        
        }

        public List<Person> Read()
        {
            List<Person> showall = dbCon.Peoples.ToList();
            return showall;
        }

        public Person Read(int id)
        {
            Person person = dbCon.Peoples.Find(id);
            return person;
        }

        public bool Update(Person person)
        {
            bool chk = false;
            Person prsn = dbCon.Peoples.Find(person.Pid);
            if(prsn!=null)
            {
                prsn.Pid = person.Pid;
                prsn.Pname = person.Pname;
                prsn.PhoneNumber = person.PhoneNumber;
                prsn.CityCode = person.CityCode;
                dbCon.SaveChanges();
                chk = true;
              }
            return chk;
        }
    }
}
