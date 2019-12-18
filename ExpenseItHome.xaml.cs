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
        private readonly List<Persons> People;
        public ExpenseItHome()
        {
            InitializeComponent();
            People = AccessDatabase.GetPersons();
            peopleListBox.ItemsSource = People;
        }

        private void PeopleListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.DataContext = this.peopleListBox.SelectedItem;
            Persons.IndexListBox = peopleListBox.SelectedIndex;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            ExpenseReportPage expenseReportPage = new ExpenseReportPage(this.peopleListBox.SelectedItem);
            this.NavigationService.Navigate(expenseReportPage);
        } 

    }
}