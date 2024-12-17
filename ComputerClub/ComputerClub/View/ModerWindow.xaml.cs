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
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using ComputerClub.ViewModel;

namespace ComputerClub.Wind
{
    /// <summary>
    /// Логика взаимодействия для ModerWindow.xaml
    /// </summary>
    public partial class ModerWindow : Window
    {


        public ModerViewModel viewModel;
       
        public ModerWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel = new ModerViewModel(this);
            viewModel.dataGridViewUsers = this.dataGridViewUsers;


            viewModel.Display_Data();
        }

        private void DragAdminWin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//для перемещения окна
        {
            DragMove();
        }



    }
}