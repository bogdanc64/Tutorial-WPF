using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseIt.Models
{
    public class ConnectionString
    {
        public static string connstring { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PeopleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
