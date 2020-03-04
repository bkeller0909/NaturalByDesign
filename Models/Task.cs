using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Task
    {
        public int ID { get; set; }

        public int Hours { get; set; }

        public string Desc { get; set; }

        public int LabourID { get; set; }

        public virtual Labour Labour { get; set; }
    }
}
