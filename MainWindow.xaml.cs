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


            this.Closing += MainWindow_Closing;
        }
        private void SetMenuVisibility()
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                // Получение текущей роли пользователя из страницы входа
                bool isAdmin = (Application.Current.MainWindow.Content as AuthPage)?.isAdmin ?? false;

                // Установка видимости элементов меню основного окна
                mainWindow.SetMenuVisibilityBasedOnRole(isAdmin);
            }
        }
        public void SetMenuVisibilityBasedOnRole(bool isAdmin)
        {
            
            // Установите видимость элементов меню в зависимости от роли
            if (isAdmin == true)
            {
                ToolsMIt.Visibility = Visibility.Visible;
            }
            else
            {
                ToolsMIt.Visibility = Visibility.Visible;
            }
            Exit.Visibility = Visibility.Visible;
            HomeMIt.Visibility = Visibility.Visible;
            CllientMIt.Visibility = Visibility.Visible;

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
                Back.Visibility = Visibility.Hidden;
                Exit.Visibility = Visibility.Hidden;
                HomeMIt.Visibility = Visibility.Hidden;
                CllientMIt.Visibility = Visibility.Hidden;
                ToolsMIt.Visibility = Visibility.Hidden;
            }
            else
            {
                SetMenuVisibility();
                Back.Visibility = Visibility.Visible;
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
            while (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
            MainFrame.GoForward();
        }
    }
}
