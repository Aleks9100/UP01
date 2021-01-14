using System;
using System.Collections.Generic;
using System.Text;

namespace UPTableDb
{
    public class Entrance
    {
        public int EntranceID { get; set; }
        public int Quantity { get; set; }
        public DateTime? Date{get;set;}
        public int? SupplierID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ItemID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Item Item { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
