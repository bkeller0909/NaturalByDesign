using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Inventory
    {
        public int ID { get; set; }

        public double AvgNetPrice { get; set; }

        public double ListPrice { get; set; }

        public int SizeValue { get; set; }

        public string SizeUnit { get; set; }

        public int Quantity { get; set; }

        public int MaterialID { get; set; }

        public virtual Material Material { get; set; }
    }
}
