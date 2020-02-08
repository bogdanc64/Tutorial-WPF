using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ExpenseIt.Models;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Page
    {
        private List<Persons> People;
        public ExpenseItHome()
        {
            InitializeComponent();
            AccessDatabase adb = new AccessDatabase();
            People = adb.GetPersons(ConnectionString.Text);
            peopleListBox.ItemsSource = People;
        }

        private void PeopleListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            
            this.DataContext = this.peopleListBox.SelectedItem;
            var nume = this.peopleListBox.SelectedItem as Persons;
            Persons.IndexListBox = peopleListBox.SelectedIndex;
            System.Console.WriteLine(nume.FirstName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            ExpenseReportPage expenseReportPage = new ExpenseReportPage(this.DataContext);
            this.NavigationService.Navigate(expenseReportPage);
        } 

    }
}