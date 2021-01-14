using System;
using System.Collections.Generic;
using System.Text;

namespace UPTableDb
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Entrance> Entrance { get; set; }
    }
}
