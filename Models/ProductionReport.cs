using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class ProductionReport
    {
        public int ID { get; set; }

        [Display(Name = "Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int ActualCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int TotalCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int ActualMtlCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstMtlCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int ActualLabourProdCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstLabourProdCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int ActualDesignCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstDesignCost { get; set; }

        public int ProjectID { get; set; }
        
        public virtual Project Project { get; set; }
    }
}
