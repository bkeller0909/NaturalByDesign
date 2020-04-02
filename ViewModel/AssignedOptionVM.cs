using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.ViewModel
{
    public class AssignedOptionVM
    {
        public int ID { get; set; }
        public string DisplayText { get; set; }
        public int Quantity { get; set; }
        public bool Assigned { get; set; }
    }
}
