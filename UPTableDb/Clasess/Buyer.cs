using System;
using System.Collections.Generic;
using System.Text;

namespace UPTableDb
{
    public class Buyer
    {
        public int BuyerID { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
