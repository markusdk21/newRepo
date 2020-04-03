using HomeDepotWebApp.Models;
using HomeDepotWebApp.Storage;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private HomeDepotContext _context;
        public List<Customer> allCostumers;
        public MainPage()
        {
            InitializeComponent();
            _context = new HomeDepotContext();
            allCostumers = _context.Customers.ToList<Customer>();
            FilterCostumers();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer c = (Customer)ListBoxKunder.SelectedItem;
            
            this.NavigationService.Content = new CostumerPage(c);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterCostumers();
        }

        private void FilterCostumers()
        {
            if (searchfield.Text.Length < 1)
            {
                this.DataContext = allCostumers;
            }
            else
            {
                List<Customer> cust = new List<Customer>();
                foreach (Customer c in allCostumers)
                {

                    if (c.Name.ToLower().Contains(searchfield.Text.ToLower()))
                    {
                        cust.Add(c);
                    }
                    else if (c.CustomerId.ToString().Contains(searchfield.Text.ToLower()))
                    {
                        cust.Add(c);
                    }
                    else if (c.Email.ToLower().Contains(searchfield.Text.ToLower()))
                    {
                        cust.Add(c);
                    }
                    else if (c.Username.ToLower().Contains(searchfield.Text.ToLower()))
                    {
                        cust.Add(c);
                    }

                }
                this.DataContext = cust;
            }
        }
        private void mExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Content = new NewC();
        }

    }
}
