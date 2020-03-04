using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class ProjectMaterials
    {
        public int ProjectID { get; set; }

        public Project Project { get; set; }

        public int MaterialID { get; set; }

        public Material Material { get; set; }

        public DateTime MatDelivery { get; set; }

        public DateTime MatInstall { get; set; }

        public int MatEstQty { get; set; }

        public int MatActQty { get; set; }
    }
}
