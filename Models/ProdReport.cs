using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class ProdReport
    {
        public int ID { get; set; }
        public Project Project { get; set; }
        public int ProjectID { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<Labour> Labour { get; set; }
    }
}
