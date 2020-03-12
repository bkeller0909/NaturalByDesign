using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Labour
    {
        public int ID { get; set; }

        [Display(Name = "Estimated Start")]
        public DateTime EstStartDate { get; set; }

        [Display(Name = "Actual Start")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Estimated Hours")]
        public int EstHours { get; set; }

        [Display(Name = "Actual Hours")]
        public int Hours { get; set; }

        public int TeamID { get; set; }

        public virtual ProjectEmployee Team { get; set; }

        public int TaskID { get; set; }

        public virtual Task Task { get; set; }
    }
}
