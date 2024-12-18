using ComputerClub.Class;
using ComputerClub.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComputerClub.Wind
{
    /// <summary>
    /// Логика взаимодействия для TimetablePage.xaml
    /// </summary>
    public partial class TimetablePage : System.Windows.Controls.Page
    {

        private TimeTableViewModel ViewModel;
        public List<Time> timetables { get; private set; }

        public SqlConnection connection;

        public TimeSpan timeschedule = new TimeSpan(0, 0, 0);

        public TimetablePage()
        {
            InitializeComponent();
            DataContext = ViewModel = new TimeTableViewModel();
            connection = ViewModel.connection;

            ViewModel.StartWorking();

            Computer.ItemsSource = ViewModel.computers;
            txt_recedure.ItemsSource = ViewModel.procedures;
        }


        private void Bt_Click(object sender, RoutedEventArgs e) //поиск по бд есть ли  в этот день бронь
        {
            if(Date.Text != "" && Computer.Text != "")
            {
                SrchSchedule();
                RegistBt.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Выберите время и компьютер!");
            }
        }



        void SrchSchedule()
        {
            List<Time> timetables = new List<Time>();
            #region bd

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                String query = "SELECT [SCHEDULE].[TimeStart], [USER_INFO].[UserId], [USER_INFO].[Name], [PROCEDURE_INFO].[Procedure], [PROCEDURE_INFO].[Durability], [PROCEDURE_INFO].[Price],[USER_INFO].[UserId],[COMPUTER_INFO].[comp_type] , [SCHEDULE].[TimeArrive],[SCHEDULE].[TimeOut] " +
                                       "FROM [SCHEDULE] " +
                                       "INNER JOIN [USER_INFO] ON [SCHEDULE].[UserId] = [USER_INFO].[ID] " +
                                       "INNER JOIN [PROCEDURE_INFO] ON [PROCEDURE_INFO].[ID] = [SCHEDULE].[ProcedureId] " +
                                       "INNER JOIN [COMPUTER_INFO] ON [COMPUTER_INFO].[computerId] = [SCHEDULE].[ComputerId]" +
                                       "WHERE [SCHEDULE].[ComputerId] = @ComputerSearch AND [Date] = @DateSearch";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                int selectedComputerId = ViewModel.computers.FirstOrDefault(c => c.Type == ViewModel.Computer)?.Id ?? 0;
                if (selectedComputerId == 0)
                {
                    MessageBox.Show("Выберите корректный компьютер.");
                    return;
                }
                command.Parameters.AddWithValue("@ComputerSearch", selectedComputerId); // id
                command.Parameters.AddWithValue("@DateSearch", Date.SelectedDate.Value);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TimeSpan time = reader.GetTimeSpan(0);
                    string user = reader.GetString(1) + " ";  // FIO user ///////
                    string procinfo = reader.GetTimeSpan(4).ToString() + "; Price: " + reader.GetDecimal(5).ToString() + "; Время прибытия: " + reader.GetTimeSpan(8) + "; Время Отбытия: " + reader.GetTimeSpan(9); 
                    string userid = reader.GetString(6);
                    Time timetable = new Time(time, user, procinfo);
                    timetables.Add(timetable);
                }

                if (timetables != null)
                {
                    Show(timetables);
                }
                ChangeComputerCoumt();
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

        #region Show
    void Show(List<Time> timetables)
        {
            int count = 1;
            foreach (var timeSlot in new[] { Time10, Time11, Time12, Time13, Time14, Time15, Time16, Time17, Time18, Time19, Time20, Time21, Time22, Time23, Time24 })
            {
                timeSlot.Text = "";
                timeSlot.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C9C9C9"));
            }

            TimeSpan[] timeSlots = new TimeSpan[]
            {
        new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0),
        new TimeSpan(14, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(16, 0, 0), new TimeSpan(17, 0, 0),
        new TimeSpan(18, 0, 0), new TimeSpan(19, 0, 0), new TimeSpan(20, 0, 0), new TimeSpan(21, 0, 0),
        new TimeSpan(22, 0, 0), new TimeSpan(23, 0, 0), new TimeSpan(24, 0, 0)
            };

            // Обработка каждого таймслота
            foreach (var timetable in timetables)
            {
                for (int i = 0; i < timeSlots.Length; i++)
                {
                    if (timetable.time == timeSlots[i])
                    {
                        var timeSlotControl = FindName($"Time{i + 10}") as TextBlock;  
                        if (timeSlotControl != null)
                        {
                            timeSlotControl.Text += count.ToString() + " " + timetable.user + " " + timetable.ProcInfo + "\n";
                            timeSlotControl.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD3113D"));
                            count++;
                        }
                    }
                }
            }
        }
        #endregion
        public void SendAnnounceToUser(string computer, string time, string proc, string compType)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                string query = @"SELECT [USER_INFO].[Email] , [Name] , [Surname]  from [USER_INFO] where [UserId] = @Userid";
                using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.Parameters.AddWithValue("@Userid", ViewModel.UserFio);
                        var result = sqlCmd.ExecuteReader();
                        if (result.Read())
                        {
                            string name = result.GetString(1);
                            string surname = result.GetString(2);
                            string semail = result.GetString(0);
                            string uemail = "ibuypowerclub@gmail.com";
                            string upass = "abap wjhp scve smmi";
                            MailAddress to = new MailAddress(semail);
                            MailAddress from = new MailAddress(uemail);
                            MailMessage message = new MailMessage(from, to)
                            {
                                Subject = "iBUYPOWER",
                                IsBodyHtml = false,
                                Body = $"Уважаемый(ая) {name} {surname}! Вы успешно забронировали компьютер {computer} ({compType}), на время {time}, по тарифу {proc}! С уважением, администрация iBUYPOWER!"
                            };
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                            {
                                Credentials = new NetworkCredential(uemail, upass),
                                EnableSsl = true
                            };
                            smtp.Send(message);
                            MessageBox.Show("Сообщение успешно отправлено!");
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Неверный формат электронной почты. Почта должна иметь окончания - @gmail/yandex/mail/bk/list и другие");
                        return;
                    }
                }
            }
        }

        public void ChangeComputerCoumt()
        {

            int itemsToShow = 0;

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string query = @"SELECT [Count] 
                     FROM [COMPUTER_INFO] 
                     WHERE [comp_type] = @ComputerType";

                using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                {
                    sqlCmd.Parameters.AddWithValue("@ComputerType", ViewModel.Computer);

                    var result = sqlCmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int count))
                    {
                        itemsToShow = count;
                    }
                }
            }


            int index = 0;
            foreach (var child in stackPanel.Children)
            {
                if (child is ListViewItem listViewItem)
                {
                    listViewItem.Visibility = index < itemsToShow ? Visibility.Visible : Visibility.Collapsed;
                    index++;
                }
            }

            if (txt_time != null && txt_time.Items.Count > 0)
            {
                index = 0;
                foreach (var item in txt_time.Items)
                {
                    if (item is ComboBoxItem comboBoxItem)
                    {
                        comboBoxItem.Visibility = index < itemsToShow ? Visibility.Visible : Visibility.Collapsed;
                        index++;
                    }
                }
            }
        }


        private void RegestrPriem_Click(object sender, RoutedEventArgs e)
        {
            int computerId = ViewModel.ComputerId();
            TimeSpan timeStart = ViewModel.TimeStartProc(txt_time.Text);
            TimeSpan timeArrive = ViewModel.TimeArriveProc(txt_timearrive.Text);
            int procedureId = ViewModel.IdProc(txt_recedure.Text);
            TimeSpan procedureDuration = ViewModel.GetProcedureDuration(procedureId);

            TimeSpan timeOut = timeArrive + procedureDuration;
            DateTime selectedDate = Date.SelectedDate.Value;

            try
            {
                if (selectedDate < DateTime.Now || selectedDate > DateTime.Now.AddMonths(1))
                {
                    MessageBox.Show("Проверьте выбранную дату!");
                    return;
                }

                if (string.IsNullOrEmpty(txt_time.Text) || string.IsNullOrEmpty(txt_timearrive.Text) || string.IsNullOrEmpty(txt_recedure.Text))
                {
                    MessageBox.Show("Все данные должны быть заполнены!");
                    return;
                }
                if (ViewModel.IsTimeSlotOccupied(computerId, selectedDate, timeArrive, timeOut, timeStart))
                {
                    MessageBox.Show("Выбранный ПК уже занят в указанный промежуток времени. Попробуйте выбрать другое время.");
                    return;
                }

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"INSERT INTO [SCHEDULE] (UserId, ComputerId, Date, TimeStart, ProcedureId,TimeArrive,TimeOut) 
                         VALUES (@UserId, @ComputerId, @Date, @TimeStart, @ProcedureId,@TimeArrive,@TimeOut)";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@UserId", ViewModel.UserId());
                sqlCmd.Parameters.AddWithValue("@ComputerId", computerId);
                sqlCmd.Parameters.AddWithValue("@Date", selectedDate);
                sqlCmd.Parameters.AddWithValue("@TimeStart", timeStart);
                sqlCmd.Parameters.AddWithValue("@ProcedureId", ViewModel.IdProc(txt_recedure.Text));
                sqlCmd.Parameters.AddWithValue("@TimeArrive", timeArrive);
                sqlCmd.Parameters.AddWithValue("@TimeOut", timeOut);
                sqlCmd.ExecuteNonQuery();

                SendAnnounceToUser(txt_time.Text, timeArrive.ToString(), txt_recedure.Text, ViewModel.Computer);

                MessageBox.Show("Запись успешно добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {"Ошибка при работе с БД!"}");
            }
            finally
            {
                connection.Close();
                SrchSchedule();
            }
        }
        void Delete()//удаление
        {
            ViewModel.IdProc(txt_recedure.Text);
           try
            {

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                if(string.IsNullOrEmpty(ViewModel.Computer) || string.IsNullOrEmpty(Date.Text))
                {
                    MessageBox.Show("Выберите дату и компьютер!");
                    return;

                }

                string query = @"
            DELETE FROM [SCHEDULE]  
            WHERE TimeStart = (
                SELECT TOP 1 TimeStart FROM [SCHEDULE] 
                WHERE TimeStart LIKE @TimeStart
                ORDER BY TimeStart DESC
            )";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@TimeStart", timeschedule);

                int rowsAffected = sqlCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Последняя запись удалена!");
                }
                else
                {
                    MessageBox.Show("Запись не найдена!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с БД!");
            }
            finally
            {
                SrchSchedule();
                connection.Close();
            }

        }

        private void TimeClick(object sender, RoutedEventArgs e)//кнопка добавить
        {
            string name = ((System.Windows.Controls.Button)sender).Name;
            switch (name)
            {
                case "Btn10":
                    timeschedule = new TimeSpan(10, 0, 0);
                    break;
                case "Btn11":
                    timeschedule = new TimeSpan(11, 0, 0);
                    break;
                case "Btn12":
                    timeschedule = new TimeSpan(12, 0, 0);
                    break;
                case "Btn13":
                    timeschedule = new TimeSpan(13, 0, 0);
                    break;
                case "Btn14":
                    timeschedule = new TimeSpan(14, 0, 0);
                    break;
                case "Btn15":
                    timeschedule = new TimeSpan(15, 0, 0);
                    break;
                case "Btn16":
                    timeschedule = new TimeSpan(16, 0, 0);
                    break;
                case "Btn17":
                    timeschedule = new TimeSpan(17, 0, 0);
                    break;
                case "Btn18":
                    timeschedule = new TimeSpan(18, 0, 0);
                    break;
                case "Btn19":
                    timeschedule = new TimeSpan(19, 0, 0);
                    break;
                case "Btn20":
                    timeschedule = new TimeSpan(20, 0, 0);
                    break;
                case "Btn21":
                    timeschedule = new TimeSpan(21, 0, 0);
                    break;
                case "Btn22":
                    timeschedule = new TimeSpan(22, 0, 0);
                    break;
                case "Btn23":
                    timeschedule = new TimeSpan(23, 0, 0);
                    break;
                case "Btn24":
                    timeschedule = new TimeSpan(24, 0, 0);
                    break;
            }
            Delete();
        }
    }
}