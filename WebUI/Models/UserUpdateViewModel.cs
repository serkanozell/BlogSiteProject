using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class UserUpdateViewModel
    {
        public string NameSurName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ImageURL { get; set; }
        public string Password { get; set; }
    }
}
