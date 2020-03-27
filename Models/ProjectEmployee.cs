using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class ProjectEmployee
    {
        public ProjectEmployee()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int ID { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }

        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Labour> Labours { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
