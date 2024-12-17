using Microsoft.Win32;
using ComputerClub.Class;
using ComputerClub.ViewModel;
using ComputerClub.Wind;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;


namespace ComputerClub.ViewModel
{


    public class PersonViewModel : INotifyPropertyChanged
    {

        public DataGrid _dataGridViewUsers;



        private string _searchLogin;
        private string _searchSurname;

        public DataGrid dataGridViewUsers
        {
            get => _dataGridViewUsers;
            set
            {
                _dataGridViewUsers = value;
                OnPropertyChanged(nameof(_searchLogin));
            }
        }


        public string SearchSurname
        {
            get => _searchSurname;
            set
            {
                _searchSurname = value;
                OnPropertyChanged(nameof(_searchSurname));
            }
        }

        public string SearchLogin
        {
            get => _searchLogin;
            set
            {
                _searchLogin = value;
                OnPropertyChanged(nameof(_searchLogin));
            }
        }


        public SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30");//подключение бд


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ICommand RefreshCommand { get; set; }
        public ICommand SearchSurnameCommand { get; set; }
        public ICommand SearchLoginCommand { get; set; }

        public PersonViewModel()
        {
            RefreshCommand = new RelayCommand(Refuse_Click);
            SearchSurnameCommand = new RelayCommand(SearchSurname_Click);
            SearchLoginCommand = new RelayCommand(SearchLog_Click);


        }


        public void Display_Data() //показ DataBase [USER_INFO]
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT [UserId] as 'Логин', [Surname] as 'Фамилия', [Name] as 'Имя', [Patronymic] as 'Отчество', [DateBirth] as 'Дата рождения', [Email] as 'Почта', [Mobile] as 'Телефон' FROM [USER_INFO]";
                    cmd.ExecuteNonQuery();
                    DataTable dta = new DataTable();
                    SqlDataAdapter dtaAdp = new SqlDataAdapter(cmd);
                    dtaAdp.Fill(dta);
                    dataGridViewUsers.ItemsSource = dta.DefaultView;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с БД!");
            }
            finally
            {
                sqlCon.Close();
            }


        }

        private void Refuse_Click(object sender)//обновить
        {
            Display_Data();
        }

        private void SearchLog_Click(object sender)//поиск по логину
        {
            try
            {
                if (SearchLogin != "")
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT [UserId] as 'Логин', [Surname] as 'Фамилия', [Name] as 'Имя', [Patronymic] as 'Отчество', [DateBirth] as 'Дата рождения', [Email] as 'Почта', [Mobile] as 'Телефон' FROM [USER_INFO] WHERE [UserId] LIKE @logi";
                        cmd.Parameters.AddWithValue("@logi", SearchLogin);
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridViewUsers.ItemsSource = dt.DefaultView;
                        sqlCon.Close();
                        SearchLogin = "";
                    }
                }
                else
                {
                    MessageBox.Show("Для поиска нужно ввести слово!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат!");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void SearchSurname_Click(object sender)
        {
            try
            {
                if (SearchSurname != "")
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT [UserId] as 'Логин', [Surname] as 'Фамилия', [Name] as 'Имя', [Patronymic] as 'Отчество', [DateBirth] as 'Дата рождения', [Email] as 'Почта', [Mobile] as 'Телефон' FROM [USER_INFO] WHERE [Surname] LIKE @surn";
                        cmd.Parameters.AddWithValue("@surn", SearchSurname);
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridViewUsers.ItemsSource = dt.DefaultView;
                        sqlCon.Close();
                        SearchSurname = "";
                    }
                }
                else
                {
                    MessageBox.Show("Для поиска нужно ввести слово!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с БД!");
            }
            finally
            {
                sqlCon.Close();
            }
        }


    }
}
