using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Material
    {
        public Material()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int ID { get; set; }

        public string Type { get; set; }

        [Display(Name = "Description")]
        public string Desc { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
