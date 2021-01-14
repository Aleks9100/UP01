using System;
using System.Collections.Generic;
using System.Text;

namespace UPTableDb
{
   public class Category
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Buyer> Buyer { get; set; }
    }
}
