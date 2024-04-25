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
    /// Логика взаимодействия для AdmMainPage.xaml
    /// </summary>
    public partial class AdmMainPage : Page
    {
        public AdmMainPage()
        {
            InitializeComponent();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Clients());
        }

        private void Credit_access_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateAcc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RedactAccs());
        }
    }
}
