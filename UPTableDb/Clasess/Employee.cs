using System;
using System.Collections.Generic;
using System.Text;

namespace UPTableDb
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        public string Phone { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public int? PositonID { get; set; }
        public int? UserID { get; set; }
        public virtual Position Position { get; set; }     
        public virtual User User { get; set; }
        public virtual ICollection<Entrance> Entrance { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }

    }
}
