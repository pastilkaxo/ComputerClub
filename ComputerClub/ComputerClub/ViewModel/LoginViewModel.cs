using ComputerClub.Wind;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ComputerClub.ViewModel
{
    public class LoginViewModel
    {
        private string _username;
        private string _usernameForgotPass;
        private string _password;

        public static string Online_person { get; private set; }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }


        public string UsernameP
        {
            get => _usernameForgotPass;
            set
            {
                _usernameForgotPass = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand DragCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
            RegisterCommand = new RelayCommand(ExecuteRegister);
            CloseCommand = new RelayCommand(ExecuteClose);
            DragCommand = new RelayCommand(ExecuteDrag);
            ForgotPasswordCommand = new RelayCommand(ExecuteForgotPassword);
        }


        private void ExecuteForgotPassword(object parameter)
        {
          
            if (!string.IsNullOrWhiteSpace(UsernameP))
            {
                UpdatePasswordForgotStatus(UsernameP, true);
                UsernameP = "";
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите логин.");
            }
        }

        private void ExecuteLogin(object parameter)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30");

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
                {
                    string query = "SELECT [USER].role FROM [USER] WHERE ID=@ID AND password=HASHBYTES('SHA2_256', @password) ";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon)
                    {
                        CommandType = CommandType.Text
                    };
                    sqlCmd.Parameters.AddWithValue("@ID", Username);
                    sqlCmd.Parameters.AddWithValue("@password", Password);
                    string role = Convert.ToString(sqlCmd.ExecuteScalar());


                    if (role == "admin")
                    {
                        OpenWindow(new AdminWindow(Username));
                    }
                    else if (role == "user")
                    {
                        OpenWindow(new UserWindow(Username));
                    }
                    else
                    {
                        MessageBox.Show("Такой логин/пароль не существует!");
                    }
                }
                else
                {
                    MessageBox.Show("Поля не могут быть пустые!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при входе!");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void ExecuteRegister(object parameter)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Application.Current.MainWindow.Close();
        }

        private void ExecuteClose(object parameter)
        {
            Application.Current.Shutdown();
        }

        private void ExecuteDrag(object parameter)
        {
            if (parameter is Window window)
            {
                window.DragMove();
            }
        }

        private void OpenWindow(Window window)
        {

            Online_person = Username;
            window.Show();
            Application.Current.MainWindow.Close();
        }


        private void UpdatePasswordForgotStatus(string username, bool isForgotten)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30");

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                string queryCheck = "SELECT [USER].[Id]  FROM [USER] WHERE Id = @Username";
                SqlCommand sqlCmdCheck = new SqlCommand(queryCheck, sqlCon)
                {
                    CommandType = CommandType.Text
                };
                sqlCmdCheck.Parameters.AddWithValue("@Username", username);
                if (sqlCmdCheck.ExecuteScalar() == null)
                {
                    MessageBox.Show("Такого логина не найдено!");
                    return;
                }

                // Запрос для обновления поля IsPasswordForgotten
                string query = "UPDATE [USER] SET [passForgot] = @IsForgotten WHERE Id = @Username";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon)
                {
                    CommandType = CommandType.Text
                };

                // Добавляем параметры в запрос
                sqlCmd.Parameters.AddWithValue("@Username", username);
                sqlCmd.Parameters.AddWithValue("@IsForgotten", isForgotten ? 1 : 0);  // 1 - если забыли пароль, 0 - если не забыли

                sqlCmd.ExecuteNonQuery(); // Выполняем запрос
                MessageBox.Show("Запрос обновлен успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении статуса сброса пароля!");
            }
            finally
            {
                sqlCon.Close();
            }
        }


    }
}
