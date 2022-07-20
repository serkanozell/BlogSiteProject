using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Name - Surname")]
        [Required(ErrorMessage = "Please Enter Name - Surname")]
        public string NameSurname { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Passwords are not same")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "E-Mail Address")]
        [Required(ErrorMessage = "Please Enter Your E-Mail Address")]
        public string Mail { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please Enter Username")]
        public string UserName { get; set; }
    }
}
