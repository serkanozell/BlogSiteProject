using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Enter a Role Name!!")]
        public string Name { get; set; }
    }
}
