using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Employee
    {
        /*{"The INSERT statement conflicted with the FOREIGN KEY constraint 
         * \"FK_Projects_Employees_DesignerID\". The conflict occurred in database 
         * \"NBDContext-ba2a395c-c92b-48f0-afa5-a1ee9a29d832\", table 
         * \"MC.Employees\", column 'Id'.\r\nThe statement has been terminated."}*/
        public Employee()
        {
            Projects = new HashSet<Project>();
            ProjectEmployees = new HashSet<ProjectEmployee>();
        }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="Employee Must Have First Name")]
        public string FirstName { get; set; }

        [Display(Name="Last Name")]
        [Required(ErrorMessage = "Employee Must Have Last Name")]
        public string LastName { get; set; }
        
        public int EmployeeTypeID { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

    }
}
