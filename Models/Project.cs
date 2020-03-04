using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Project
    {
        public Project()
        {
            Labour = new HashSet<Labour>();
            ProjectEmployees = new HashSet<ProjectEmployee>();
            ProjectMaterials = new HashSet<ProjectMaterials>();
        }

        public int ID { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Project Must Have Name")]
        [StringLength(30, ErrorMessage = "Project Name Must Be 30 Characters or Less")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(100, ErrorMessage = "Must Be 100 Characters or Less")]
        public string Desc { get; set; }

        [Display(Name = "Estimated Cost")]
        public double EstCost { get; set; }

        [Display(Name = "Bid Date")]
        public DateTime BidDate { get; set; }

        [Display(Name = "Estimated Start Date")]
        public DateTime EstStartDate { get; set; }

        [Display(Name = "Estimated Finish Date")]
        public DateTime EstFinishDate { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Finish Date")]
        public DateTime? FinishDate { get; set; }

        public double? Cost { get; set; }

        [Display(Name = "Customer Approved")]
        public bool BidCustApproved { get; set; }

        [Display(Name = "Management Approved")]
        public bool BidManagementApproved { get; set; }

        public int ClientID { get; set; }

        public virtual Client Client { get; set; }

        public int DesignerID { get; set; }

        public virtual Employee Designer { get; set; }

        public virtual ICollection<Labour> Labour { get; set; }

        public ICollection<ProjectMaterials> ProjectMaterials { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
