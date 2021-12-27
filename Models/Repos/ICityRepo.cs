using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApplication.Models.Repos
{
     public interface ICityRepo
    {
        Cities Create(Cities city);
        List<Cities> Read();
        Cities Read(int id);
        bool Update(Cities city);
        bool Delete(Cities city);
    }
}
