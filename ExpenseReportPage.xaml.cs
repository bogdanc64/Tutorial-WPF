using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using ExpenseIt.Models;

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
            AccessDatabase adb = new AccessDatabase();
            DataGrid.DataContext = adb.GetExpenses(ConnectionString.connstring);
            this.DataContext = data;
        }
    }
  
}
