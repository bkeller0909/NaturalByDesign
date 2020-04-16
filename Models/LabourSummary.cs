using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class LabourSummary
    {
        public LabourSummary()
        {
            EmployeeType = new EmployeeType();
        }

        [Display(Name = "Extended Price")]
        [DataType(DataType.Currency)]
        public double ExtPrice
        {
            get
            {
                return Hours * EmployeeType.HourlyCost; 
            }
            
        }

        public int ProjectID { get; set; }

        public Project Project { get; set; }

        public int EmployeeTypeID { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public int Hours { get; set; }
    }
}
