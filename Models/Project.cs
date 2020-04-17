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
            LabourSummaries = new HashSet<LabourSummary>();
            ProjectEmployees = new HashSet<ProjectEmployee>();
            ProjectMaterials = new HashSet<ProjectMaterials>();
        }

        public int ID { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Project Must Have Name")]
        [StringLength(30, ErrorMessage = "Project Name Must Be 30 Characters or Less")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Project Must Have Description")]
        [StringLength(100, ErrorMessage = "Must Be 100 Characters or Less")]
        public string Desc { get; set; }

        [Display(Name = "Estimated Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Bid Must Have Estimated Cost")]
        public double EstCost { get; set; }

        [Display(Name = "Bid Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BidDate { get; set; }

        [Display(Name = "Estimated Start Date")]
        [Required(ErrorMessage = "Bid Must Have Estimated Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstStartDate { get; set; }

        [Display(Name = "Estimated Finish Date")]
        [Required(ErrorMessage = "Bid Must Have Estimated Finish Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstFinishDate { get; set; }

        [Display(Name = "Phase")]
        public string CurrentPhase { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Finish Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FinishDate { get; set; }

        [DataType(DataType.Currency)]
        public double? Cost { get; set; }

        [Display(Name = "Customer Approved")]
        public bool BidCustApproved { get; set; }

        [Display(Name = "Management Approved")]
        public bool BidManagementApproved { get; set; }

        public int ClientID { get; set; }

        public virtual Client Client { get; set; }

        public int DesignerID { get; set; }

        public virtual Employee Designer { get; set; }

        [Display(Name ="Production")]
        public virtual ICollection<ProjectMaterials> ProjectMaterials { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

        public virtual ICollection<LabourSummary> LabourSummaries { get; set; }
    }
}
