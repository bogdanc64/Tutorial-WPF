using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace ExpenseIt.Models
{
    public class AccessDatabase
    {
        public List<Persons> GetPersons(string connString)
        {
            SqlConnection con;
            try
            {
                con = new SqlConnection(connString);
            }
            catch (Exception)
            {
                throw new Exception("Invalid connection string");
            }

            var datesql = con.Query<Persons>("select FirstName, LastName, Department from Employees").ToList();
            //datesql = AddNewPerson(datesql);
            return datesql;
        }
        /* Persons newPerson = new Persons
            {
                FirstName = "Bogdan",
                Department = "CNMK"
            };*/
        public List<Persons> AddNewPerson(List<Persons> datesql)
        {
            Persons newPerson = new Persons
            {
                FirstName = "Bogdan",
                Department = "CNMK"
            };
            datesql.Add(newPerson);
            return datesql;
        }
        public DataSet GetExpenses(string connString)
        {
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("Select ExpenseType, Amount, Employee_ID from Expenses where Employee_ID = @index", con);
            var index = cmd.Parameters.AddWithValue("@index",Persons.IndexListBox+1);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            var dt = new DataSet();
            ad.Fill(dt);
            return dt;
        }
    }
}
 