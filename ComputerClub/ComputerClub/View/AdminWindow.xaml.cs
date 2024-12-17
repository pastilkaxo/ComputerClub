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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using ComputerClub.Class;
using ComputerClub.ViewModel;

namespace ComputerClub.Wind
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {


        public AdminViewModel adminView;
        public AdminWindow(string regUserLogin)
        {
            InitializeComponent();
            this.DataContext = adminView = new AdminViewModel(regUserLogin,this);

            adminView.AdFrameNavigation = AdFrameNavigation;
            adminView.AdFrameNavigation2 = AdFrameNavigation2;
            adminView.AdFrameNavigation.Content = new HomePage();

           
        }

        private void DragAdminWin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//для перемещения окна
        {
            DragMove(); 
        }

       
    }
}