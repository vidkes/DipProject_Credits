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
        public Clients()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)

            {

                CreditsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());

                DataGridUser.ItemsSource = CreditsEntities.GetContext().Client_data.ToList();

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
    }
}
