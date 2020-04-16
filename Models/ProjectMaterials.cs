using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class ProjectMaterials
    {
        public ProjectMaterials()
        {
            Inventory = new Inventory();
            
        }

        [Display(Name = "Ext. Cost")]
        [DataType(DataType.Currency)]
        public double MatTotalPrice
        {
            get
            {
                return Inventory.AvgNetPrice * MatEstQty;
            }
        }

        public int ProjectID { get; set; }

        public Project Project { get; set; }

        public int InventoryID { get; set; }

        public Inventory Inventory { get; set; }

        [Display(Name = "Material Delivery")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MatDelivery { get; set; }

        [Display(Name = "Material Install")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MatInstall { get; set; }

        [Display(Name = "Material Estimated Quantity")]
        public int MatEstQty { get; set; }

        [Display(Name = "Material Actual Quantity")]
        public int MatActQty { get; set; }
    }
}
