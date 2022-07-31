using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter You Password")]
        public string Password { get; set; }
    }
}
