using credit_normal;
using credit_normal.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace credit_normal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            clock.Content = dateTime.ToString();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result =
            MessageBox.Show("Закрыть приложение?", "Выход",
            MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            while (MainFrame.NavigationService.CanGoBack)
            {
                this.MainFrame.GoBack();
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"credit - {page.Title}";

            if (page is Pages.AuthPage)
            {
                Exit.Visibility = Visibility.Hidden;
                HomeMIt.Visibility = Visibility.Hidden;
                CllientMIt.Visibility = Visibility.Hidden;
                OperMIt.Visibility = Visibility.Hidden;
                ToolsMIt.Visibility = Visibility.Hidden;
            }
            else if (page is Pages.MainPage)
            {
                Exit.Visibility = Visibility.Visible;
                HomeMIt.Visibility = Visibility.Visible;
                CllientMIt.Visibility = Visibility.Visible;
                OperMIt.Visibility = Visibility.Visible;
                ToolsMIt.Visibility = Visibility.Hidden;
            }
            else
            {
                Exit.Visibility = Visibility.Visible;
                HomeMIt.Visibility = Visibility.Visible;
                CllientMIt.Visibility = Visibility.Visible;
                OperMIt.Visibility = Visibility.Visible;
                ToolsMIt.Visibility = Visibility.Visible;
            }
                
        }
        private void CrAcc_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService?.Navigate(new CreateAcc(null));
        }

        private void RedAccs_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService?.Navigate(new RedactAccs());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack();
        }

        private void CllientMIt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService?.Navigate(new Clients());
        }

        private void HomeMIt_Click(object sender, RoutedEventArgs e)
        {
            CreditsEntities db = new CreditsEntities();
            var usr = db.Accounts.FirstOrDefault();
            if (usr.Role == true)
            {
                MainFrame.NavigationService?.Navigate(new AdmMainPage());
            }
            else MainFrame.NavigationService?.Navigate(new MainPage());
        }
    }
}

// код для базы
/*private static CreditsEntities _context;
public CreditsEntities()
            : base("name=CreditsEntities")
        {
}
public static CreditsEntities GetContext()

{

    if (_context == null)

        _context = new CreditsEntities();

    return _context;

}*/
