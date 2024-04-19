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
    /// Логика взаимодействия для RedactAccs.xaml
    /// </summary>
    public partial class RedactAccs : Page
    {
        public RedactAccs()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)

        {

            if (Visibility == Visibility.Visible)

            {

                CreditsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());

                DataGridUser.ItemsSource = CreditsEntities.GetContext().Accounts.ToList();

            }

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateAcc((sender as Button).DataContext as Accounts));
        }
        
        private void createAcc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateAcc(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Подтверждение удаления
            var usersForRemoving = DataGridUser.SelectedItems.Cast<Accounts>().ToList();

            if (MessageBox.Show("Вы точно хотите удалить запись?", "Внимание",

            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Удаление данных
                try
                {
                    CreditsEntities.GetContext().Accounts.RemoveRange(usersForRemoving);

                    CreditsEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные успешно удалены!");

                    DataGridUser.ItemsSource = CreditsEntities.GetContext().Accounts.ToList();

                }

                catch (Exception ex)

                {

                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }
    }
}
