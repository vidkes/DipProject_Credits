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
            // Проверка на пустой логин или пароль
            if (string.IsNullOrWhiteSpace(Login.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми.");
                return;
            }

            using (CreditsEntities db = new CreditsEntities())
            {
                // Проверка существует ли пользователь по ID
                var usr = db.Accounts.FirstOrDefault(u => u.ID == _currentUser.ID);

                if (usr != null)
                {
                    // Обновление данных пользователя
                    usr.Login = Login.Text;
                    usr.Password = Password.Text;
                    usr.Role = Role.SelectedIndex == 1;

                    MessageBox.Show("Данные пользователя обновлены.");
                }
                else
                {
                    // Проверка, существует ли пользователь с таким же логином
                    var loginExists = db.Accounts.Any(u => u.Login == Login.Text);
                    if (loginExists)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует.");
                        return;
                    }

                    // Создание нового пользователя
                    _currentUser.Login = Login.Text;
                    _currentUser.Password = Password.Text;
                    _currentUser.Role = Role.SelectedIndex == 1;

                    db.Accounts.Add(_currentUser);
                    MessageBox.Show("Пользователь зарегистрирован.");
                }

                db.SaveChanges();
            }

            // Очистка полей после сохранения
            Login.Text = "";
            Password.Text = "";
            Role.SelectedIndex = 0;

            // Переход на страницу RedactAccs
            NavigationService?.Navigate(new RedactAccs());
        }
    }
}
