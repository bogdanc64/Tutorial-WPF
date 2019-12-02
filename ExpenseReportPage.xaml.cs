using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseReportPage.xaml
    /// </summary>
    
    public partial class ExpenseReportPage : Page
    {
        public ExpenseReportPage()
        {
            InitializeComponent();


        }

        // Custom constructor to pass expense report data
        public ExpenseReportPage(object data):this()
        {
            this.DataContext = data;
            int x = Variabile.indexListBox;
            int IndexEmployee =  x + 1;
            // Bind to expense report data.
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PeopleDB;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("Select ExpenseType, Amount, Employee_ID from Expenses where Employee_ID = @IndexEmployee", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            con.Open();
            cmd.Parameters.Add("@IndexEmployee", IndexEmployee);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Expenses");
            DataGrid.DataContext = ds;
            con.Close();
        }

    }
  
}
