using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Created by Sean

namespace NBDv2.Models
{
    public class City
    {
        public City()
        {
            this.Clients = new HashSet<Client>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
