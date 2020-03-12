using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Task
    {
        public Task()
        {
            Labours = new HashSet<Labour>();
        }

        public int ID { get; set; }

        public int Hours { get; set; }

        public string Desc { get; set; }

        public string ResponsibilityType { get; set; }

        public virtual ICollection<Labour> Labours { get; set; }
    }
}