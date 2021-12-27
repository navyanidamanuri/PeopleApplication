using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PeopleApplication.Models.ViewModels
{
    public class CreatePersonViewModel
    {   [Key]
        [Required]
        public int Pid { get; set; }
        [Required]
        public string Pname { get; set; }
        [Required]
        public string PhoneNumber{ get; set;}
        [Required]
        public int CityCode { get; set; }
    }
}
