using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeopleApplication.Models.ViewModels
{
    public class CountryViewModel
    {   [Key]
        public int CrtyCode { get; set; }
        [Required]
        public string CrtyName { get; set; }
    }
}
