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
    /// Логика взаимодействия для RepPage.xaml
    /// </summary>
    public partial class RepPage : Page
    {
        public RepPage()
        {
            InitializeComponent();

            Rep rep = new Rep();

            if (rep.INN == true) InnRep.Text = "ИНН действителен";
            if (rep.INN == false) InnRep.Text = "ИНН не действителен";

            if (rep.Wanted == true) WantedRep.Text = "Находится в розыске";
            if (rep.Wanted == false) WantedRep.Text = "Не в розыске";
        }

    }
}
