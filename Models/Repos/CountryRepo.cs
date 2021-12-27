using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PeopleApplication.Models.Repos
{
    public class CountryRepo : ICountryRepo
    {
        readonly PeopleContext dbCon;
        public CountryRepo(PeopleContext dbCon)
        {
            this.dbCon = dbCon;
        }

        Country ICountryRepo.Create(Country country)
        {
            dbCon.countries.Add(country);
            dbCon.SaveChanges();
            return country;
        }

        bool ICountryRepo.Delete(Country country)
        {
            bool chk = false;
            Country ctry = dbCon.countries.Find(country.CrtyCode);
            if(ctry!=null)
            {
                dbCon.countries.Remove(country);
                dbCon.SaveChanges();
                chk = true;
            }
            return chk;
        }

        List<Country> ICountryRepo.Read()
        {
            List<Country> showallCountries = dbCon.countries.ToList();
            return showallCountries;
        }

        Country ICountryRepo.Read(int id)
        {
            Country country = dbCon.countries.Find(id);
            return country;
        }

        bool ICountryRepo.update(Country country) 
        {
            bool chk = false;
            Country ctry = dbCon.countries.Find(country.CrtyCode);
            if(ctry!=null)
            {
                ctry.CrtyCode = country.CrtyCode;
                ctry.CrtyName = country.CrtyName;
                dbCon.SaveChanges();
                chk = true;

            }
            return chk;
        }
    }
}
