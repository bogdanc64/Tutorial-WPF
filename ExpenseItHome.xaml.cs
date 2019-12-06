using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Page
    {
        public ExpenseItHome()
        {
            InitializeComponent();
            fillListBox();
        }
        public void fillListBox()
        {
            SqlConnection con = new SqlConnection(@"Data Source=people-db.database.windows.net;Initial Catalog=People-DB;User Id=bodo;Password=Peopledb123;Pooling=False");
            SqlCommand cmd = new SqlCommand("select FirstName, LastName, Department from Employees", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            con.Open();
            DataSet ds = new DataSet();
            ad.Fill(ds,"Employees");
            peopleListBox.DataContext= ds;
            con.Close();
        }
        private void PeopleListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.DataContext = this.peopleListBox.SelectedItem;
            Variabile.indexListBox = peopleListBox.SelectedIndex;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            ExpenseReportPage expenseReportPage = new ExpenseReportPage(this.peopleListBox.SelectedItem);
            this.NavigationService.Navigate(expenseReportPage);

        }

    }
    public static class Variabile
    {
        public static int indexListBox;
    }
}