using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeopleApplication.Models
{
    public class Country
    {   [Key]
        public int CrtyCode { get; set; }
        public string CrtyName { get; set; }
        public ICollection<Cities> cityinfo { get; set; }
    }
}
