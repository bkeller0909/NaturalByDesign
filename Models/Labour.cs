using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class Labour
    {
        public Labour()
        {
            this.Tasks = new HashSet<Task>();
        }

        public int ID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime TimeSpent { get; set; }

        public DateTime EstStartDate { get; set; }

      

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
