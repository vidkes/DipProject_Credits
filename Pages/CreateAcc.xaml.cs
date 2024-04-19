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
    /// Логика взаимодействия для CreateAcc.xaml
    /// </summary>
    public partial class CreateAcc : Page
    {
        private Accounts _currentUser = new Accounts();
        public CreateAcc(Accounts selectedAccounts)
        {
            InitializeComponent();
            if (selectedAccounts != null)
                _currentUser = selectedAccounts;

            DataContext = _currentUser;
        }

        private void Canel_Click(object sender, RoutedEventArgs e)
        {
            Login.Text = "";
            Password.Text = "";
            Role.SelectedIndex = 0;
        }

        private void Entr_Click(object sender, RoutedEventArgs e)
        {
            //регистрация нового юзера
            CreditsEntities db = new CreditsEntities();
            var usr = db.Accounts
                .AsNoTracking()
                .FirstOrDefault(u => u.Login == Login.Text);
            try
            {
                //проверка существует ли юзер
                if (usr.Login == Login.Text)
                {
                    MessageBox.Show("Такой пользователь уже существует");
                    Login.Text = "";
                    Password.Text = "";
                    Role.SelectedIndex = 0;
                }
            }
            catch
            {
                //передача данных нового юзера в базу
                Accounts user = new Accounts();
                {
                    bool intbool;
                    user.Login = Login.Text;
                    user.Password = Password.Text;
                    if (Role.SelectedIndex == 1) intbool = true;
                    else intbool = false;
                    user.Role = intbool;

                };
                db.Accounts.Add(user);
                db.SaveChanges();
                MessageBox.Show("Пользователь зарегистрирован");
            }
            NavigationService?.Navigate(new RedactAccs());
        }
    }
}
