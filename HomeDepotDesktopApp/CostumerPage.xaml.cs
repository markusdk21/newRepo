using HomeDepotWebApp.Models;
using HomeDepotWebApp.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeDepotDesktopApp
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class CostumerPage : Page
    {
       private HomeDepotContext _context;
        public CostumerPage(Customer costumer)
        {
            _context = new HomeDepotContext();
            InitializeComponent();

            navn.Text = costumer.Name;
            email.Text = costumer.Email;
            brugerid.Text = costumer.CustomerId.ToString();
            brugernavn.Text = costumer.Username;
            password.Text = costumer.Password;
            List<Rent> bookinger = _context.Rents.Where(r => r.Customer.CustomerId.Equals(costumer.CustomerId)).ToList();
            this.DataContext = bookinger;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.Customers.AddOrUpdate(t => t.CustomerId, new Customer { CustomerId = Int32.Parse(brugerid.Text), Name = navn.Text, Email = email.Text, Password = password.Text, Username = brugernavn.Text }) ;
            _context.SaveChanges();
            this.NavigationService.Content = new MainPage();
        }

        private void mExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Content = new NewC();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Content = new MainPage();
        }

        public void GoBack()
        {
            this.NavigationService.Content = new MainPage();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rent rent = (Rent)bookinger.SelectedItem;
            this.NavigationService.Content = new RentOverview(rent);
        }

    }
}
