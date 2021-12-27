using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApplication.Models.ViewModels
{
    public class CityViewModel
    {  [Key]
        public int CityCode { get; set; }
        public string CityName { get; set; }
        public int CtryCode { get; set; }

    }
}
