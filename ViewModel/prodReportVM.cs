using NBDv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.ViewModel
{
    public class ProdReportVM
    {
        public List<Labour> Labour { get; set; }
        
        public List<ProjectMaterials> Materials { get; set; }
    }
}
