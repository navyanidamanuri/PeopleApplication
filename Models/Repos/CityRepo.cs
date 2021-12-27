using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApplication.Models.Repos
{
    public class CityRepo : ICityRepo
    {
        readonly PeopleContext dbCon;
        public CityRepo(PeopleContext dbCon)
        {
            this.dbCon = dbCon;

        }
        public Cities Create(Cities city)
        {
            dbCon.cities.Add(city);
            dbCon.SaveChanges();
            return city;
        }

        public bool Delete(Cities city)
        {
            bool chk = false;
            Cities ct = dbCon.cities.Find(city.CityCode);
            if(ct!=null)
            {
                dbCon.cities.Remove(city);
                chk = true;
            }
            return chk;

        }

        public List<Cities> Read()
        {
            return dbCon.cities.ToList(); 
        }

        public Cities Read(int id)
        {
            Cities ct = dbCon.cities.Find(id);
            return ct;
        }

        public bool Update(Cities city)
        {
            bool chk = false;
            Cities ct = dbCon.cities.Find(city.CityCode);
            if (ct != null)
            {
                ct.CityCode = city.CityCode;
                ct.CityName = city.CityName;
                ct.CtryCode = city.CtryCode;
                dbCon.SaveChanges();
                chk = true;
            }
            return chk;

        }
    }
}
