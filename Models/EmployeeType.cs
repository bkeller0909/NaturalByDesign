using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
            LabourSummaries = new HashSet<LabourSummary>();
        }

        public int ID { get; set; }

        public string Type { get; set; }

        public double HourlyPay { get; set; }

        public double HourlyCost { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<LabourSummary> LabourSummaries { get; set; }
    }
}
