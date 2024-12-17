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
using System.Data.SqlClient;
using System.Data;
using ComputerClub.ViewModel;


namespace ComputerClub.Wind
{
    /// <summary>
    /// Логика взаимодействия для PersonPage.xaml
    /// </summary>
    public partial class PersonPage : Page
    {

        public PersonViewModel personView;
        public PersonPage()
        {
            InitializeComponent();
            this.DataContext = personView = new PersonViewModel();
            personView.dataGridViewUsers = this.dataGridViewUsers1;
            personView.Display_Data();

        }


    }
}
