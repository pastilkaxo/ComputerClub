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
    /// Логика взаимодействия для AllComputers.xaml
    /// </summary>
    /// 

    public partial class AllComputers : Window
    {
        public ComputerViewModel ComputerViewModel;
        public AllComputers()
        {
            InitializeComponent();
            this.DataContext = ComputerViewModel = new ComputerViewModel();
            ComputerViewModel.dataGridViewUsers1 = this.dataGridViewUsers1;
            ComputerViewModel.Display_Data();
        }
    }
}
