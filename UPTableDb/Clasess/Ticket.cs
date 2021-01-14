using System;
using System.Collections.Generic;
using System.Text;

namespace UPTableDb
{
   public class Ticket
    {
        public int TicketID { get; set; }
        public int Quantity { get; set; }
        public DateTime? Date { get; set; }
        public decimal Result { get; set; }
        public bool Status { get; set; }
        public int? WarehouseID { get; set; }
        public int? ItemID { get; set; }
        public int? BuyerID { get; set; }
        public int? EmployeeID { get; set; }
        public virtual Buyer Buyer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Item Item { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
