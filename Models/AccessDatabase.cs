using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace ExpenseIt.Models
{
    class AccessDatabase
    {
        public static List<Persons> GetPersons()
        {
            SqlConnection con = new SqlConnection(@"Data Source=people-db.database.windows.net;Initial Catalog=People-DB;User Id=bodo;Password=Peopledb123;Pooling=False");
            var datesql = con.Query<Persons>("select FirstName, LastName, Department from Employees").ToList();
            return datesql;
        }
        public static DataSet GetExpenses()
        {
            SqlConnection con = new SqlConnection(@"Data Source=people-db.database.windows.net;Initial Catalog=People-DB;User Id=bodo;Password=Peopledb123;Pooling=False");
            SqlCommand cmd = new SqlCommand("Select ExpenseType, Amount, Employee_ID from Expenses where Employee_ID = @index", con);
            var index = cmd.Parameters.AddWithValue("@index",Persons.IndexListBox+1);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            var dt = new DataSet();
            ad.Fill(dt);
            return dt;
        }
    }
}
 