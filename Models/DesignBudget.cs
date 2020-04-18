using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class DesignBudget
    {
        public int ID { get; set; }

        [Display(Name = "Current Hours")]
        [Required(ErrorMessage = "You must enter a Time")]
        public int CurrentHours { get; set; }

        [Display(Name = "Estimated Hours")]
        [Required(ErrorMessage = "You must enter a Time")]
        public int EstHours { get; set; }

        [Display(Name = "Total Hours")]
        [Required(ErrorMessage = "You must enter a Time")]
        public int HoursTotal { get; set; }

        [Display(Name = "Submission Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a submission date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmissionDate { get; set; }

        [Display(Name = "Submitter's Name")]
        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string Submitter { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
