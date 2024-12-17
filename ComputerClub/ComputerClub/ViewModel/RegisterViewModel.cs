using ComputerClub.Helper;
using ComputerClub.Wind;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerClub.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly Window _window;
        private string _login;
        private string _password;
        private string _name;
        private string _lastName;
        private string _patronymic;
        private string _mobile;
        private string _email;
        private DateTime? _birthDate;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
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

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged();
            }
        }

        public string Mobile
        {
            get => _mobile;
            set
            {
                _mobile = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime? BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand GoToLoginCommand { get; }

        public RegisterViewModel(Window window)
        {
            _window = window;
            RegisterCommand = new RelayCommand(ExecuteRegister);
            CloseCommand = new RelayCommand(ExecuteClose);
            GoToLoginCommand = new RelayCommand(ExecuteGoToLogin);
        }

        private void ExecuteRegister(object parameter)
        {
            using (var sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30"))
            {
                sqlCon.Open();
                using (var transaction = sqlCon.BeginTransaction())
                {
                    //try
                    //{

                        //    MessageBox.Show($"Login: {Login}, Password: {Password}, Name: {Name}, " +
                        //$"LastName: {LastName}, Patronymic: {Patronymic}, Mobile: {Mobile}, " +
                        //$"Email: {Email}, BirthDate: {BirthDate}");

                       

                        if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password) &&
                            !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(LastName) &&
                            !string.IsNullOrEmpty(Patronymic) && !string.IsNullOrEmpty(Mobile) &&
                            !string.IsNullOrEmpty(Email) && BirthDate.HasValue && Email.Contains("@"))
                        {

                        string checkMobileQuery = "SELECT COUNT(*) FROM [USER_INFO] WHERE Mobile = @mob";
                        using (var checkMobileCmd = new SqlCommand(checkMobileQuery, sqlCon, transaction))
                        {
                            checkMobileCmd.Parameters.AddWithValue("@mob", Mobile);
                            int mobileCount = (int)checkMobileCmd.ExecuteScalar();
                            if (mobileCount > 0)
                            {
                                MessageBox.Show("Этот номер телефона уже зарегистрирован.");
                                return;
                            }
                        }

                        string checkEmailQuery = "SELECT COUNT(*) FROM [USER_INFO] WHERE Email = @em";
                        using (var checkEmailCmd = new SqlCommand(checkEmailQuery, sqlCon, transaction))
                        {
                            checkEmailCmd.Parameters.AddWithValue("@em", Email);
                            int emailCount = (int)checkEmailCmd.ExecuteScalar();
                            if (emailCount > 0)
                            {
                                MessageBox.Show("Этот email уже зарегистрирован.");
                                return;
                            }
                        }

                        string query1 = "INSERT INTO [USER] (ID, password) VALUES (@user, HASHBYTES('SHA2_256', @pass))";
                            using (var sqlCmd = new SqlCommand(query1, sqlCon, transaction))
                            {
                                sqlCmd.Parameters.AddWithValue("@user", Login);
                                sqlCmd.Parameters.AddWithValue("@pass", Password);
                                sqlCmd.ExecuteNonQuery();
                            }

                            string query2 = "INSERT INTO [USER_INFO] (Userid, Name, Surname, Patronymic, Mobile, Email, DateBirth) VALUES (@userman, @name, @surname, @patro, @mob, @email, @dateb)";
                            using (var sqlCmd2 = new SqlCommand(query2, sqlCon, transaction))
                            {
                                sqlCmd2.Parameters.AddWithValue("@userman", Login);
                                sqlCmd2.Parameters.AddWithValue("@name", Name);
                                sqlCmd2.Parameters.AddWithValue("@surname", LastName);
                                sqlCmd2.Parameters.AddWithValue("@patro", Patronymic);
                                sqlCmd2.Parameters.AddWithValue("@mob", Mobile);
                                sqlCmd2.Parameters.AddWithValue("@email", Email);
                                sqlCmd2.Parameters.AddWithValue("@dateb", BirthDate);
                                sqlCmd2.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Congratulations! Registration successful.");
                        }
                        else
                        {
                            MessageBox.Show("Все поля должны быть заполнены!");
                        }
                    //}
                    //catch (Exception ex)
                    //{
                    //    transaction.Rollback();
                    //    MessageBox.Show($"Все поля должны быть заполнены корректно!");
                    //}
                }
            }
        }

        private void ExecuteClose(object parameter)
        {
            _window.Close();
        }

        private void ExecuteGoToLogin(object parameter)
        {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                 _window.Close();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
