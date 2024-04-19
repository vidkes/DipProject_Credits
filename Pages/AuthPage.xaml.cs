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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Entr_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CreditsEntities())
            {
                var user = db.Accounts
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == Login.Text && u.Password == Password.Password);

                //username check
                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }
                //user role check
                switch (user.Role)
                {
                    case true:
                        NavigationService?.Navigate(new AdmMainPage());
                        break;
                    case false:
                        NavigationService?.Navigate(new MainPage());
                        break;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AdmMainPage());
        }
    }
}
