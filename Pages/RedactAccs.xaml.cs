﻿using System;
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
            CreateAcc acc = new CreateAcc((sender as Button).DataContext as Accounts);
            NavigationService?.Navigate(acc);
        }
        
        private void createAcc_Click(object sender, RoutedEventArgs e)
        {
            CreateAcc acc = new CreateAcc(null);
            NavigationService?.Navigate(acc);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
             var usersForRemoving = DataGridUser.SelectedItems.Cast<Accounts>().ToList();

            if (MessageBox.Show("Вы точно хотите удалить запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var protectedUsers = usersForRemoving.Where(u => u.Login == "admin" && u.Password == "admin").ToList();

                if (protectedUsers.Count > 0)
                {
                    MessageBox.Show("Нельзя удалить базовый админ аккаунт.");
                    // Удаление защищенных пользователей из списка для удаления
                    usersForRemoving = usersForRemoving.Except(protectedUsers).ToList();
                }

                if (usersForRemoving.Count > 0)
                {
                    try
                    {
                        CreditsEntities.GetContext().Accounts.RemoveRange(usersForRemoving);
                        CreditsEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные успешно удалены!");

                        // Обновление источника данных DataGrid
                        DataGridUser.ItemsSource = CreditsEntities.GetContext().Accounts.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Нет данных для удаления.");
                }
            }

        }
    }
}
