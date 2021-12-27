using PeopleApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApplication.Models.Repos;

namespace PeopleApplication.Models.Services
{
    public class CityService : ICityService
    {
        readonly ICityRepo cityRepo;
        public CityService(ICityRepo cityRepo)
        {
            this.cityRepo = cityRepo;
        }
        public Cities AddCity(CityViewModel cityViewModel)
        {
            Cities ct = new Cities();
            ct.CityCode = cityViewModel.CityCode;
            ct.CityName = cityViewModel.CityName;
            ct.CtryCode = cityViewModel.CtryCode;
            cityRepo.Create(ct);
            return ct;
        }

        public List<Cities> AllCities()
        {
            return cityRepo.Read();
        }

        public bool Edit(int id, CityViewModel cvm)
        {
            Cities ct = new Cities();
            ct.CityCode = cvm.CityCode;
            ct.CityName = cvm.CityName;
            ct.CtryCode = cvm.CtryCode;
            bool chk = cityRepo.Update(ct);
            return chk;
        }

        public Cities FindById(int id)
        {
            return cityRepo.Read(id);
        }

        public bool Remove(int id)
        {
            bool chk = cityRepo.Delete(cityRepo.Read(id));
            return chk;
        }
    }
}
