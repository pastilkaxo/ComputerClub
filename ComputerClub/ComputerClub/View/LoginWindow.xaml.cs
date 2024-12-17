using ComputerClub.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {


        public static string Online_person;
        public LoginViewModel viewModel;
        public LoginWindow()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            this.DataContext  = viewModel;

            viewModel.Password = txt_user.Text;

        }
        private void BorderDrag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }




        private void txt_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(viewModel == null)
            {
                return;
            }
            viewModel.Password = txt_password.Password;
        }
    }
}
