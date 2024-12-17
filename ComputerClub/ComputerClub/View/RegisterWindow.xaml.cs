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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterViewModel registerView;
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = registerView  = new RegisterViewModel(this);
        }

        private void txt_pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(registerView == null)
            {
                return;
            }
            registerView.Password = txt_pass.Password;
        }

        private void BorderDrag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//для передвижения окна за статусбар
        {
            DragMove();
        }

        private void CloseLog_Click(object sender, RoutedEventArgs e)//закрыть
        {
            Application.Current.Shutdown();
        }

    }
}
