using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class ProjectMaterials
    {
        [Display(Name = "Ext. Cost")]
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

        public DateTime MatDelivery { get; set; }

        public DateTime MatInstall { get; set; }

        public int MatEstQty { get; set; }

        public int MatActQty { get; set; }
    }
}
