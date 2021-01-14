using System;
using System.Collections.Generic;
using System.Text;

namespace UPTableDb
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Entrance> Entrance { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
