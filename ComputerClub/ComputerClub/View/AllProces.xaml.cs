using ComputerClub.ViewModel;
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
using System.Windows.Shapes;

namespace ComputerClub.Wind
{
    /// <summary>
    /// Логика взаимодействия для AllProces.xaml
    /// </summary>
    public partial class AllProces : Window
    {
        public ServiceViewModel ServiceViewModel;
        public AllProces()
        {
            InitializeComponent();
            this.DataContext = ServiceViewModel = new ServiceViewModel();
            ServiceViewModel.dataGridViewUsers1 = this.dataGridViewUsers1;
            ServiceViewModel.Display_Data();
        }
    }
}
