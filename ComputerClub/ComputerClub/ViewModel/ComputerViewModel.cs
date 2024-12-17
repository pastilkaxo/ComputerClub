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
    public class ComputerViewModel : INotifyPropertyChanged
    {

        public DataGrid _dataGridViewUsers1;



        private string _searchProcessor;
        private string _searchType;


        private Computer _selectedComputer = new Computer();
        public Computer SelectedComputer
        {
            get => _selectedComputer;
            set
            {
                _selectedComputer = value;
                OnPropertyChanged(nameof(SelectedComputer));
            }
        }

        public DataGrid dataGridViewUsers1
        {
            get => _dataGridViewUsers1;
            set
            {
                _dataGridViewUsers1 = value;
                OnPropertyChanged(nameof(SearchProcessor));
            }
        }


        public string SearchProcessor
        {
            get => _searchProcessor;
            set
            {
                _searchProcessor = value;
                OnPropertyChanged(nameof(SearchProcessor));
            }
        }

        public string SearchType
        {
            get => _searchType;
            set
            {
                _searchType = value;
                OnPropertyChanged(nameof(SearchType));
            }
        }


        public SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30");//подключение бд


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ICommand RefreshCommand { get; set; }
        public ICommand SearchProcessorCommand { get; set; }
        public ICommand SearchTypeCommand { get; set; }
        public ICommand DeleteLastCommand { get; set; }
        public ICommand UpdateCommand { get; }
        public ComputerViewModel()
        {
            RefreshCommand = new RelayCommand(Refuse_Click);
            SearchProcessorCommand = new RelayCommand(SearchProcessor_Click);
            SearchTypeCommand = new RelayCommand(SearchType_Click);
            DeleteLastCommand = new RelayCommand(DeleteLast_Click);
            UpdateCommand = new RelayCommand(UpdateComputer);
        }


        private void Refuse_Click(object param)//обновить
        {
            Display_Data();
        }


        private void UpdateComputer(object param)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                if (string.IsNullOrEmpty(SelectedComputer.Type) ||
                    SelectedComputer.Id == 0||
                    SelectedComputer.Id == null ||
                    string.IsNullOrEmpty(SelectedComputer.Processor) ||
                    string.IsNullOrEmpty(SelectedComputer.Videocard) ||
                    string.IsNullOrEmpty(SelectedComputer.RAM) ||
                    string.IsNullOrEmpty(SelectedComputer.CompDesc) ||
                    SelectedComputer.Count <= 0 ||
                    SelectedComputer.Count > 15)
                {
                    MessageBox.Show("Все поля должны быть заполнены, а количество должно быть больше нуля и меньше 15!");
                    return;
                }

                string query = "UPDATE [COMPUTER_INFO] SET " +
                               "comp_type = @Type, " +
                               "comp_processor = @Processor, " +
                               "comp_videocard = @Videocard, " +
                               "comp_ram = @RAM, " +
                               "comp_desc = @Description, " +
                               "Count = @Count " +
                               "WHERE computerId = @cid";

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@cid", SelectedComputer.Id);
                cmd.Parameters.AddWithValue("@Type", SelectedComputer.Type);
                cmd.Parameters.AddWithValue("@Processor", SelectedComputer.Processor);
                cmd.Parameters.AddWithValue("@Videocard", SelectedComputer.Videocard);
                cmd.Parameters.AddWithValue("@RAM", SelectedComputer.RAM);
                cmd.Parameters.AddWithValue("@Description", SelectedComputer.CompDesc);
                cmd.Parameters.AddWithValue("@Count", SelectedComputer.Count);

                SelectedComputer = null;    


                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены!");

                Display_Data(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка изменения в БД!");
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
            DELETE FROM [COMPUTER_INFO]
            WHERE [computerId] = (
                SELECT TOP 1 [computerId]
                FROM [COMPUTER_INFO]
                ORDER BY [computerId] DESC
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
                MessageBox.Show($"Ошибка при удалении! Кто-то уже забронировал этот компьютер!");
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
                    cmd.CommandText = "SELECT [computerId] as 'ИД',[comp_type] as 'Тип', [comp_processor] as 'Процессор', [comp_videocard] as 'Видеокарта', [comp_ram] as 'ОЗУ', [comp_desc] as 'Описание' , [Count] as 'Колличество' FROM [COMPUTER_INFO]";
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


        private void SearchProcessor_Click(object param)//поиск по названию процедуры
        {
            try
            {
                if (SearchProcessor != "")
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT [computerId] as 'ИД',[comp_type] as 'Тип', [comp_processor] as 'Процессор', [comp_videocard] as 'Видеокарта', [comp_ram] as 'ОЗУ', [comp_desc] as 'Описание' , [Count] as 'Колличество' FROM [COMPUTER_INFO] WHERE [comp_processor] LIKE @proc";
                        cmd.Parameters.AddWithValue("@proc", SearchProcessor);
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridViewUsers1.ItemsSource = dt.DefaultView;

                        SearchProcessor = "";
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

        private void SearchType_Click(object param)
        {
            try
            {
                if (SearchType != "")
                {
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT [computerId] as 'ИД',[comp_type] as 'Тип', [comp_processor] as 'Процессор', [comp_videocard] as 'Видеокарта', [comp_ram] as 'ОЗУ', [comp_desc] as 'Описание', [Count] as 'Колличество' FROM [COMPUTER_INFO] WHERE [comp_type] ='" + SearchType + "'";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridViewUsers1.ItemsSource = dt.DefaultView;

                        SearchType = "";
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
