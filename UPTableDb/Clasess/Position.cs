using System;
using System.Collections.Generic;
using System.Text;

namespace UPTableDb
{
   public class Position
    {
        public int PositionID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
