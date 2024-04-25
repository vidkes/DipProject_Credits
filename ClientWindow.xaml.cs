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

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Inn.Text))
            {
                MessageBox.Show("поле ИНН пустое");
            }
            //регистрация нового client
            CreditsEntities db = new CreditsEntities();
            int pass = Convert.ToInt32(Passport.Text);
            var existingClient = db.Client_data.FirstOrDefault(u => u.Passport == pass);
            //проверка существует ли client
            if (existingClient != null)
            {
                MessageBox.Show("Нельзя повторно внести клиента в базу");
                return;
            }
            //передача данных client в базу
            Client_data client_ = new Client_data();
            Rep re = new Rep();
            FSSP fSSP = new FSSP();
            Tax_debit tax = new Tax_debit();
            Bankrupcy bankr = new Bankrupcy();
            {
                client_.First_name = I.Text;
                client_.Last_name = F.Text;
                client_.Father_name = O.Text;
                client_.Sex = sex.SelectedIndex == 1;
                client_.Passport = pass;
                client_.INN = (int?)Convert.ToInt64(Inn.Text);
                client_.Marriage = Marriage.SelectedIndex == 1;
                client_.Passport_adress = Adress.Text;
                client_.Real_adress = RealAdress.Text;
                client_.Job = Job.Text;
                client_.Job_position = JobPos.Text;
                try
                {
                    float salCount = float.Parse(Salary.Text);
                    client_.salary = salCount;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите сумму дохода через запятую");
                    return;
                }
                client_.Credit_score = 67.48;
                re.Wanted = false;
                re.INN = true;
            }; 
            db.FSSP.Add(fSSP);
            db.Tax_debit.Add(tax);
            db.Bankrupcy.Add(bankr);

            re.FSSP = fSSP.ID;
            re.Tax_debits = tax.ID;
            re.Bankruptcy = bankr.ID;
            db.Rep.Add(re);

            client_.report = re.ID;
            db.Client_data.Add(client_);
            db.SaveChanges();

            MessageBox.Show("Клиент успешно зарегетрирован");

            Close();
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
