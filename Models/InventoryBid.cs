﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDv2.Models
{
    public class InventoryBid
    {
        public int BidID { get; set; }

        public virtual Bid Bid { get; set; }

        public int ItemID { get; set; }

        //public virtual Item Item { get; set; }
    }
}
