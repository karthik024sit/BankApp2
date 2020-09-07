using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BankApp2.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage ="please enter your email")]
        [Display(Name ="enter username:")]
        public string email { get; set; }

        [Required(ErrorMessage = "please enter your password")]
        [Display(Name = "enter password:")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}