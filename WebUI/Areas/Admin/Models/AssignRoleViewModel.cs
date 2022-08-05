using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Models
{
    public class AssignRoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Exist { get; set; }
    }
}
