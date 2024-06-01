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

namespace credit_normal.Pages
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        private List<Client_data> _clients;
        private List<Client_data> _filteredClients;
        public Clients()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)

            {
                CreditsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                _clients = CreditsEntities.GetContext().Client_data.ToList();
                _filteredClients = new List<Client_data>(_clients);
                DataGridUser.ItemsSource = _filteredClients;
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow(null);
            clientWindow.save.Visibility = Visibility.Visible;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow((sender as Button).DataContext as Client_data);
            clientWindow.RepBut.Visibility = Visibility.Visible;
        }

        private void serch_Click(object sender, RoutedEventArgs e)
        {
            FilterClients();
        }
        private void FilterClients()
        {
            if (_clients == null) return;

            var searchText = srctext.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                _filteredClients = new List<Client_data>(_clients);
            }
            else
            {
                _filteredClients = _clients.Where(c =>
                    c.Last_name.ToLower().Contains(searchText) ||
                    c.First_name.ToLower().Contains(searchText) ||
                    c.Father_name.ToLower().Contains(searchText) ||
                    c.Passport.ToString().Contains(searchText) ||
                    c.INN.ToString().Contains(searchText)).ToList();
            }

            DataGridUser.ItemsSource = _filteredClients;
        }
    }
}
