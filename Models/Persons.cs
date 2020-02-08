using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace ExpenseIt.Models
{
    public class Persons
    {
        public int ID { get; set; }
        public static int IndexListBox { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }

        public string FullName { get { return (string)$"{FirstName} {LastName}"; } }
       
    }
}
