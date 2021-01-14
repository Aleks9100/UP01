using System;
using System.Collections.Generic;
using System.Text;

namespace UPTableDb
{
   public class Warehouse
    {
        public int WarehouseID { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
        public virtual Item Item { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
