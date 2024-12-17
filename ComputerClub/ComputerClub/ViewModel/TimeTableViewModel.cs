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
    public class TimeTableViewModel : INotifyPropertyChanged
    {

        private string _fullname;
        private string _computer;
        private string _procedure;
        public string UserFio { get => _fullname; set { _fullname = value; OnPropertyChanged(); } }

        public string Computer
        {
            get => _computer;
            set
            {
                _computer = value;
                OnPropertyChanged();
            }
        }



        public string Procedure
        {
            get => _procedure;
            set
            {
                _procedure = value;
                OnPropertyChanged();
            }
        }


        public List<Computer> computers { get; set; }
        public List<User> users { get; set; }
        public List<Procedure> procedures { get; set; }

        public SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30");


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public TimeTableViewModel(/*List<Computer> _computers,List<User> _users,List<Procedure> _procedures*/)
        {

            //this.computers = _computers;
            //this.users = _users;
            //this.procedures = _procedures;


            computers = new List<Computer>();
            users = new List<User>();
            procedures = new List<Procedure>();

        }


        public void StartWorking()
        {

            #region bd подключение компьютера

            //подключить

            try
            {

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                String query = "SELECT   [COMPUTER_INFO].[computerId],  [COMPUTER_INFO].[comp_type] FROM [COMPUTER_INFO]";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string type = reader.GetString(1);

                    Computer computer = new Computer(Id, type);
                    computers.Add(computer);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с БД!");
            }

            finally
            {
                connection.Close();
            }
            #endregion

            #region bd подключенеи юзера

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                String query = "SELECT   [USER_INFO].[ID],  [USER_INFO].[Name],  [USER_INFO].[Surname], [USER_INFO].[Patronymic] FROM [USER_INFO]";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Name = reader.GetString(1);
                    string Surname = reader.GetString(2);
                    string Patronymic = reader.GetString(3);

                    User user = new User(Id, Surname + " " + Name + " " + Patronymic);//фио
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с БД!");
            }
            finally
            {
                connection.Close();
            }

            #endregion  //доделать поиск юзеров

            #region bd подключение процедур

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                String query = "SELECT [PROCEDURE_INFO].[Procedure], [PROCEDURE_INFO].[ID]  FROM [PROCEDURE_INFO]";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string Name = reader.GetString(0);
                    int ID = reader.GetInt32(1);

                    Procedure procedure = new Procedure(Name, ID);
                    procedures.Add(procedure);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с БД!");
            }

            finally
            {
                connection.Close();
            }
            #endregion

        }




        #region Convert 
        public int IdProc(string prsSrch) //срабатывает регистрации тарифов, находит по строке нужны ай ди из списков
        {
            int idProc = 0;
            if (procedures != null && procedures.Count != 0)
            {
                for (int i = 0; i < procedures.Count; i++)
                {
                    if (procedures[i].Name.ToString() == prsSrch)
                        idProc = procedures[i].ID;
                }
            }
            return idProc;
        }

        public int UserId()
        {
            int userId = 0;
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            string query = "SELECT [ID] FROM [USER_INFO] WHERE [UserId] = @Login";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Login", UserFio);

            object result = command.ExecuteScalar();

            if (result != null)
            {
                userId = Convert.ToInt32(result);
            }
            else
            {
                MessageBox.Show("Пользователь с указанным логином не найден.");
            }



            return userId;
        }


        public int ComputerId()
        {
            int dc = 0;
            for (int i = 0; i < computers.Count; i++)
            {
                if (computers[i].Type == Computer)
                    dc = computers[i].Id;
            }
            return dc;
        }


        #endregion

        public TimeSpan TimeArriveProc(string time)
        {
            TimeSpan timeArrive = new TimeSpan(0, 0, 0);
            if (TimeSpan.TryParse(time, out TimeSpan parsedTime))
            {
                if (parsedTime >= new TimeSpan(0, 0, 0) && parsedTime <= new TimeSpan(23, 30, 0) && parsedTime.Minutes % 30 == 0)
                {
                    timeArrive = parsedTime;
                }

            }

            return timeArrive;
        }

        public TimeSpan TimeOutProc(string time)
        {
            TimeSpan timeOutProc = new TimeSpan(0, 0, 0);

            if (TimeSpan.TryParse(time, out TimeSpan parsedTime))
            {
                if (parsedTime >= new TimeSpan(10, 0, 0) && parsedTime <= new TimeSpan(24, 0, 0) && parsedTime.Minutes % 30 == 0)
                {
                    timeOutProc = parsedTime;
                }
            }
            return timeOutProc;
        }
        public TimeSpan TimeStartProc(string time)
        {
            TimeSpan timeStartProc = new TimeSpan(0, 0, 0);

            switch (time)
            {
                case "PC1":
                    timeStartProc = new TimeSpan(10, 0, 0);
                    break;
                case "PC2":
                    timeStartProc = new TimeSpan(11, 0, 0);
                    break;
                case "PC3":
                    timeStartProc = new TimeSpan(12, 0, 0);
                    break;
                case "PC4":
                    timeStartProc = new TimeSpan(13, 0, 0);
                    break;
                case "PC5":
                    timeStartProc = new TimeSpan(14, 0, 0);
                    break;
                case "PC6":
                    timeStartProc = new TimeSpan(15, 0, 0);
                    break;
                case "PC7":
                    timeStartProc = new TimeSpan(16, 0, 0);
                    break;
                case "PC8":
                    timeStartProc = new TimeSpan(17, 0, 0);
                    break;
                case "PC9":
                    timeStartProc = new TimeSpan(18, 0, 0);
                    break;
                case "PC10":
                    timeStartProc = new TimeSpan(19, 0, 0);
                    break;
                case "PC11":
                    timeStartProc = new TimeSpan(20, 0, 0);
                    break;
                case "PC12":
                    timeStartProc = new TimeSpan(21, 0, 0);
                    break;
                case "PC13":
                    timeStartProc = new TimeSpan(22, 0, 0);
                    break;
                case "PC14":
                    timeStartProc = new TimeSpan(23, 0, 0);
                    break;
                case "PC15":
                    timeStartProc = new TimeSpan(24, 0, 0);
                    break;
            }
            return timeStartProc;

        }
        public TimeSpan GetProcedureDuration(int procedureId)
        {
            TimeSpan duration = TimeSpan.Zero;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"SELECT [Durability] FROM [PROCEDURE_INFO] WHERE [ID] = @ProcedureId";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.Parameters.AddWithValue("@ProcedureId", procedureId);

                var result = sqlCmd.ExecuteScalar();
                if (result != null && TimeSpan.TryParse(result.ToString(), out duration))
                {
                    return duration;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении длительности процедуры: " + "Ошибка при работе с БД!");
            }
            finally
            {
                connection.Close();
            }

            return duration;
        }

        public bool IsTimeSlotOccupied(int computerId, DateTime date, TimeSpan timeArrive, TimeSpan timeOut, TimeSpan timeStart)
        {
            bool isOccupied = false;

            try
            {
                // Проверяем, что время выхода не раньше времени прибытия
                if (timeOut <= timeArrive)
                {
                    MessageBox.Show("Время выхода не может быть раньше или равно времени прибытия!");
                    return true;
                }

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Мы ищем все записи, у которых время прибытия и выхода пересекаются с новым интервалом
                string query = @"SELECT TimeArrive, TimeOut 
                         FROM [SCHEDULE] 
                         WHERE [ComputerId] = @ComputerId 
                         AND [Date] = @Date
                        AND [TimeStart] = @TimeStart";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ComputerId", computerId);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@TimeStart", timeStart);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TimeSpan existingArrive = reader.GetTimeSpan(0);  // Время прибытия существующей записи
                    TimeSpan existingOut = reader.GetTimeSpan(1);     // Время выхода существующей записи

                    // Проверка на пересечение интервалов
                    // Новый интервал [timeArrive, timeOut] не должен пересекаться с уже существующим
                    if ((timeArrive < existingOut && timeOut > existingArrive))
                    {
                        isOccupied = true;
                        break; // Если хотя бы одно пересечение найдено, выходим из цикла
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка проверки занятости времени: {"Ошибка при работе с БД!"}");
            }
            finally
            {
                connection.Close();
            }

            return isOccupied;
        }




    }
}
