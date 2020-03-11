using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class EmployeeType
    {
        public int ID { get; set; }

        public string Type { get; set; }

        public double HourlyPay { get; set; }

        public double HourlyCost { get; set; }

        public int MyProperty { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
