using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Task
    {
        public Task()
        {
            Labours = new HashSet<Labour>();
        }

        public int ID { get; set; }

        public int Hours { get; set; }

        public string Desc { get; set; }

        public ICollection<Labour> Labours { get; set; }
    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NBDv2.Models
//{
//    public class EmployeeType
//    {
//        public EmployeeType()
//        {
//            Employees = new HashSet<Employee>();
//        }
//        public int ID { get; set; }

//        [Display(Name="Employee Type")]
//        public string Type { get; set; }

//        [Display(Name = "Hourly Wage")]
//        public double HourlyPay { get; set; }

//        [Display(Name = "Hourly Charge")]
//        public double HourlyCharge { get; set; }

//        public ICollection<Employee> Employees { get; set; }
//    }
//}

