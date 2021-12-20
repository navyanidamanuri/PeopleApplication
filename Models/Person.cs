using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeopleApplication.Models
{
    public class Person
    {   [Key]
        public int Pid { get; set; }
        public string Pname { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }
}
