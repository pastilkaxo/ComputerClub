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
    public class ServiceViewModel : INotifyPropertyChanged
    {

        public DataGrid _dataGridViewUsers1;



        private string _searchProcName;
        private string _searchPrice;
        private Procedure _selectedProc = new Procedure();
        public Procedure SelectedProc
        {
            get => _selectedProc;
            set
            {
                _selectedProc = value;
                OnPropertyChanged(nameof(SelectedProc));
            }
        }
        public DataGrid dataGridViewUsers1
        {
            get => _dataGridViewUsers1;
            set
            {
                _dataGridViewUsers1 = value;
                OnPropertyChanged(nameof(SearchProcName));
            }
        }


        public string SearchProcName
        {
            get => _searchProcName;
            set
            {
                _searchProcName = value;
                OnPropertyChanged(nameof(SearchProcName));
            }
        }

        public string SearchPrice
        {
            get => _searchPrice;
            set
            {
                _searchPrice = value;
                OnPropertyChanged(nameof(SearchPrice));
            }
        }


        public SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30");//подключение бд


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ICommand RefreshCommand { get; set; }
        public ICommand SearchProcedureCommand { get; set; }
        public ICommand SearchPriceCommand { get; set; }
        public ICommand DeleteLastCommand { get; set; }
        public ICommand UpdateCommand { get; }
        public ServiceViewModel() 
        {
            RefreshCommand = new RelayCommand(Refuse_Click);
            SearchProcedureCommand = new RelayCommand(SearchProcedure_Click);
            SearchPriceCommand = new RelayCommand(SearchPrice_Click);
            DeleteLastCommand = new RelayCommand(DeleteLast_Click);
            UpdateCommand = new RelayCommand(UpdateProc);
        }


        private void Refuse_Click(object param)//обновить
        {
            Display_Data();
        }


        private void UpdateProc(object param)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();


                string query = "UPDATE [PROCEDURE_INFO] SET " +
                               "[Procedure] = @proc, " +
                               "Price = @price, " +
                               "Durability = @durab, " +
                               "Description = @desc " +
                               "WHERE ID = @pid";

                if (SelectedProc == null ||
                    string.IsNullOrWhiteSpace(SelectedProc.ID.ToString()) ||
                    string.IsNullOrWhiteSpace(SelectedProc.Name) ||
                    string.IsNullOrWhiteSpace(SelectedProc.Durability.ToString()) ||
                    string.IsNullOrWhiteSpace(SelectedProc.Price.ToString()) ||
                    string.IsNullOrWhiteSpace(SelectedProc.Description))
                {
                    MessageBox.Show("Все поля должны быть заполнены и не содержать только пробелы!");
                    return;
                }


                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@pid", SelectedProc.ID);
                cmd.Parameters.AddWithValue("@proc", SelectedProc.Name);
                cmd.Parameters.AddWithValue("@durab", SelectedProc.Durability);
                cmd.Parameters.AddWithValue("@price", SelectedProc.Price);
                cmd.Parameters.AddWithValue("@desc", SelectedProc.Description);


                SelectedProc = null;


                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены!");

                Display_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка изменения в БД! {ex.Message}");
            }
            finally
            {
                sqlCon.Close();
            }
        }


        private void DeleteLast_Click(object param)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                string query = @"
            DELETE FROM [PROCEDURE_INFO]
            WHERE [Procedure] = (
                SELECT TOP 1 [Procedure]
                FROM [PROCEDURE_INFO]
                ORDER BY [ID] DESC
            )";

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Последняя запись успешно удалена!");
                }
                else
                {
                    MessageBox.Show("Записи для удаления не найдены.");
                }
                Display_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении! Кто-то уже купил этот тариф!");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public void Display_Data() 
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT [ID] as 'ИД',[Procedure] as 'Название', [Durability] as 'Длительность', [Price] as 'Цена', [Description] as 'Описание' FROM [PROCEDURE_INFO]";
                    cmd.ExecuteNonQuery();
                    DataTable dta = new DataTable();
                    SqlDataAdapter dtaAdp = new SqlDataAdapter(cmd);
                    dtaAdp.Fill(dta);
                    dataGridViewUsers1.ItemsSource = dta.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отоброжения тарифов!");
            }
            finally
            {
                sqlCon.Close();
            }
        }


        private void SearchProcedure_Click(object param)//поиск по названию тарифа
        {
            try
            {
                if (SearchProcName != "")
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT [ID] as 'ИД', [Procedure] as 'Название', [Durability] as 'Длительность', [Price] as 'Цена', [Description] as 'Описание' FROM [PROCEDURE_INFO] WHERE [Procedure] LIKE @proc";
                        cmd.Parameters.AddWithValue("@proc", SearchProcName);
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridViewUsers1.ItemsSource = dt.DefaultView;

                        SearchProcName = "";
                    }
                }
                else
                {
                    MessageBox.Show("Для поиска нужно ввести слово!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void SearchPrice_Click(object param)//поиск тарифа по цене
        {
            try
            {
                if (SearchPrice != "")
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT [ID] as 'ИД',[Procedure] as 'Название', [Durability] as 'Длительность', [Price] as 'Цена', [Description] as 'Описание' FROM [PROCEDURE_INFO] WHERE [Price] = '" + SearchPrice + "'";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridViewUsers1.ItemsSource = dt.DefaultView;

                        SearchPrice = "";
                    }
                }
                else
                {
                    MessageBox.Show("Для поиска нужно ввести слово!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат");
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
