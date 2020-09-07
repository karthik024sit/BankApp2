using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankApp2.Models
{
    public class ValidateClass
    {
        [Required(ErrorMessage ="enter email id to regsiter")]
        [Display(Name ="enter email id:")]
        [EmailAddress(ErrorMessage ="enter the proper email address!")]
        public string email { get; set; }

        [Required]
        [Display(Name ="enter password:")]
        [DataType(DataType.Password)]
        public string password { get; set; }


    }
}