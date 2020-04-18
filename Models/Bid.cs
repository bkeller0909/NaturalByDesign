using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// Created by Brandon

namespace NBDv2.Models
{
    public class Bid
    {
        public Bid()
        {
            InvBids = new HashSet<InventoryBid>();
        }

        public int ID { get; set; }

        [Display(Name = "Bid")]
        [Required(ErrorMessage = "You must enter an ID")]
        [RegularExpression("^[A-Z\\d]{12}$", ErrorMessage = "Please enter all Capital letters.")]
        [StringLength(12, ErrorMessage = "Blueprint Code must be 12 Characters long")]
        public string BidID { get; set; }

        [Display(Name = "Estimated Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstStart { get; set; }

        [Display(Name = "Estimated End Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter an end Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstEnd { get; set; }

        [Display(Name = "Total Estimated Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter an amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Amount { get; set; }

        [Display(Name = "Location")]
        [RegularExpression("^[A-Za-z\\s\\d]+$", ErrorMessage = "Please enter a valid amount.")]
        public string Location { get; set; }

        public ICollection<InventoryBid> InvBids { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
