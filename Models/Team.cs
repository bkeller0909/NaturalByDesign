using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Team
    {
        public Team()
        {
            Employees = new HashSet<Employee>();
        }

        public int ID { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "You can not leave this project name field blank")]
        [StringLength(100, ErrorMessage = "Project name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Department Description")]
        [Required(ErrorMessage = "You cannot leave the unit description blank")]
        [StringLength(250, ErrorMessage = "The description cannot be more than 250 characters long.")]
        public string DepartmentDescription { get; set; }

        public int ProductionID { get; set; }

        public virtual Project Projects { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}