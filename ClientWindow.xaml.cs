using credit_normal.Pages;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace credit_normal
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private Client_data _currentClient = new Client_data();
        public ClientWindow(Client_data selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
                _currentClient = selectedClient;

            DataContext = _currentClient;
        }

        public event Action OnClientDataUpdated;

        //private float ScoreCalc()
        //{
        //    using (CreditsEntities db = new CreditsEntities())
        //    {
        //        var clnt = db.Client_data

        //        if (clnt.salary < 45000)
        //        {

        //        }

        //        return scored;
        //    }
        //}
        private void save_Click(object sender, RoutedEventArgs e)
        {
            double scored = 0;
            // Валидация данных
            if (string.IsNullOrEmpty(Inn.Text))
            {
                MessageBox.Show("Поле ИНН пустое");
                return;
            }

            if (!int.TryParse(Passport.Text, out int pass))
            {
                MessageBox.Show("Некорректный паспортный номер");
                return;
            }

            if (!long.TryParse(Inn.Text, out long inn))
            {
                MessageBox.Show("Некорректный ИНН");
                return;
            }

            if (!float.TryParse(Salary.Text, out float salCount))
            {
                MessageBox.Show("Введите сумму дохода через запятую");
                return;
            }

            Random random = new Random();
            double randomNumber = random.NextDouble() * 100;
            scored = Math.Round(randomNumber, 2);
            using (CreditsEntities db = new CreditsEntities())
            {
                // Проверка существует ли клиент
                var client = db.Client_data.FirstOrDefault(u => u.Passport == pass);
                bool isNewClient = client == null;

                if (isNewClient)
                {
                    // Новый клиент
                    client = new Client_data();
                    db.Client_data.Add(client);
                }
                else
                {
                    // Обновление существующего клиента
                    if (MessageBox.Show("Клиент уже существует. Обновить данные?", "Обновление клиента", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                    {
                        return;
                    }
                }

                // Заполнение данных клиента
                client.First_name = I.Text;
                client.Last_name = F.Text;
                client.Father_name = O.Text;
                client.Sex = sex.SelectedIndex == 1;
                client.Passport = pass;
                client.INN = (int?)inn;
                client.Marriage = Marriage.SelectedIndex == 1;
                client.Adress = Adress.Text;
                client.Real_adress = RealAdress.Text;
                client.Job = Job.Text;
                client.Job_position = JobPos.Text;
                client.salary = salCount;

                
                client.Credit_score = scored;
                

                // Создание отчетов только для нового клиента
                if (client.report == null)
                {
                    Rep re = new Rep();
                    FSSP fSSP = new FSSP();
                    Tax_debit tax = new Tax_debit();
                    Bankrupcy bankr = new Bankrupcy();

                    re.Wanted = false;
                    re.INN = true;

                    db.FSSP.Add(fSSP);
                    db.Tax_debit.Add(tax);
                    db.Bankrupcy.Add(bankr);
                    db.SaveChanges();

                    re.FSSP = fSSP.ID;
                    re.Tax_debits = tax.ID;
                    re.Bankruptcy = bankr.ID;
                    db.Rep.Add(re);
                    db.SaveChanges();

                    client.report = re.ID;
                }

                db.SaveChanges();

                if (OnClientDataUpdated != null)
                {
                    OnClientDataUpdated.Invoke();
                }

                MessageBox.Show(isNewClient ? "Клиент успешно зарегистрирован" : "Данные клиента успешно обновлены");

                if (isNewClient)
                {
                    Close();
                }
            }
        }


        private void Rep_Click(object sender, RoutedEventArgs e)
        {
            RepFrame.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
            RepBut.Visibility = Visibility.Hidden;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            RepFrame.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
            RepBut.Visibility = Visibility.Visible;
        }
    }
}
