using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Material
    {
        public Material()
        {
            ProjectMaterials = new HashSet<ProjectMaterials>();
        }

        public int ID { get; set; }

        public string Type { get; set; }

        public string Desc { get; set; }

        public virtual Inventory Inventory { get; set; }

        public ICollection<ProjectMaterials> ProjectMaterials { get; set; }
    }
}
