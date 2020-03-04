using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.ViewModel
{
    public class UserVM
    {
        public string ID { get; set; }

        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Display(Name = "Roles")]
        public IList<string> UserRoles { get; set; }
    }

    public class RoleVM
    {
        public string RoleID { get; set; }

        public string RoleName { get; set; }

        public bool Assigned { get; set; }
    }
}
