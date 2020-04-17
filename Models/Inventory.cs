using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Inventory 
    {
        public Inventory()
        {
            ProjectMaterials = new HashSet<ProjectMaterials>();
        }

        [Display(Name = "Full Name")]
        public string Size
        {
            get
            {
                return SizeValue + " " + SizeUnit;
            }
        }

        public int ID { get; set; }

        [Display(Name = "Avg. Net Price")]
        [DataType(DataType.Currency)]
        public double AvgNetPrice { get; set; }

        [Display(Name = "List Price")]
        [DataType(DataType.Currency)]
        public double ListPrice { get; set; }

        [Display(Name = "Size Value")]
        public int SizeValue { get; set; }

        [Display(Name = "Size Unit")]
        public string SizeUnit { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Material ID")]
        public int MaterialID { get; set; }

        public virtual Material Material { get; set; }

        public virtual ICollection<ProjectMaterials> ProjectMaterials { get; set; }

    }
}
