using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Task Must Have Hours")]
        public int Hours { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Task Must Have Description")]
        public string Desc { get; set; }

        [Display(Name = "Responisiblity Type")]
        [Required(ErrorMessage = "Task Must Have Description")]
        public string ResponsibilityType { get; set; }

        public virtual ICollection<Labour> Labours { get; set; }
    }
}