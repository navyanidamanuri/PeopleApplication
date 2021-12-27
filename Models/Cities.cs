using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeopleApplication.Models
{
    public class Cities
    {   [Key]
        public int CityCode { get; set; }
        public string CityName { get; set; }
        public int CtryCode { get; set; }

        public Country country { get; set; }
        public ICollection<Person> person { get; set; }

    }
}
