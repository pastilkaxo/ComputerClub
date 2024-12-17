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
using System.Net.Mail;
using System.Net;

namespace ComputerClub.ViewModel
{
    public class ModerViewModel : INotifyPropertyChanged
    {
        public Window wind;
        private DataGrid _grid;
        public DataGrid dataGridViewUsers { get => _grid; set { _grid = value; OnPropertyChanged(); } }


        private string _insertId;
        private string _insertPassword;
        private string _insertRole;

        public string txt_insertID { get => _insertId; set { _insertId = value; OnPropertyChanged(); } }
        public string txt_insertPassword { get => _insertPassword; set { _insertPassword = value; OnPropertyChanged(); } }
        public string txt_insertRole { get => _insertRole; set { _insertRole = value; OnPropertyChanged(); } }

        private string _searchId;

        public string txt_SearchID { get => _searchId; set { _searchId = value; OnPropertyChanged(); } }



        public SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30");//подключение бд


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AdminClose { get; }

        public ICommand ChangeAcc { get; }


        public ICommand HelpBtn { get; }

        public ICommand AboutBtn { get; }
        public ICommand InsertCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand RefreshCommand { get; }
        public ModerViewModel(Window window)
        {
            this.wind = window;
            AdminClose = new RelayCommand(AdminClose_Click);
            ChangeAcc = new RelayCommand(ChangeAcc_Click);
            HelpBtn = new RelayCommand(HelpBut_Click);
            AboutBtn = new RelayCommand(AboutBtn_Click);
            InsertCommand = new RelayCommand(Insert_Click);
            DeleteCommand = new RelayCommand(Delete_CLick);
            UpdateCommand = new RelayCommand(Update_Click);
            SearchCommand = new RelayCommand(SearchLog_Click);
            RefreshCommand = new RelayCommand(Refuse_Click);

        }

        #region =Menu=


        private void AdminClose_Click(object sender)//закрыть окно
        {
            wind.Close();
        }

        private void ChangeAcc_Click(object sender)//поменять акк
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            wind.Close();
        }

        #endregion

        #region=PopUp=
        private void HelpBut_Click(object sender)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }

        private void AboutBtn_Click(object sender)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
        #endregion


        public void SendAnnounceToUser(string userid)
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
                        sqlCmd.Parameters.AddWithValue("@Userid", userid);
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
                                Body = $"Уважаемый(ая) {name} {surname}! Ваш пароль был успешно изменен на временный : {txt_insertPassword}\nПожалуйста не сообщайте никому и измените его в ближайшее время, если вам нужно! С уважением, администрация iBUYPOWER!"
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


        #region =Кнопки работы c DataBase=
        private void Insert_Click(object sender)//подтвердить
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)//проверка на подключение к бд
                {
                    if (txt_insertID != "" && txt_insertPassword != "" && txt_insertRole != "")//проверка на пустые строки
                    {
                        if (txt_insertRole == "user" || txt_insertRole == "admin")//проверка на нужную роль
                        {
                            sqlCon.Open();
                            SqlCommand cmd = sqlCon.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into [USER] (ID, password, role) values ('" + txt_insertID + "', HASHBYTES('SHA2_256','" + txt_insertPassword + "'), '" + txt_insertRole + "')";
                            cmd.ExecuteNonQuery();
                            sqlCon.Close();
                            Display_Data();

                            txt_insertID = "";
                            txt_insertPassword = "";
                            txt_insertRole = "";

                            MessageBox.Show("Добавлено!");
                        }
                        else
                        {
                            MessageBox.Show("Роль может быть только:\nuser\nadmin");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поля не могут быть пустые!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении пользователя!");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public void Display_Data() //показ DataBase [USER]
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [USER]";
                    cmd.ExecuteNonQuery();
                    DataTable dta = new DataTable();
                    SqlDataAdapter dtaAdp = new SqlDataAdapter(cmd);
                    dtaAdp.Fill(dta);
                    dataGridViewUsers.ItemsSource = dta.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отображения пользователе!");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void Refuse_Click(object sender)//обновить DB
        {
            Display_Data();
        }

        private void Delete_CLick(object sender)//удалить запись
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    if (txt_insertID != "")//проверка на пустые строки
                    {
                        sqlCon.Open();
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = 
                            "DELETE FROM [USER_INFO] WHERE [UserId] = '" + txt_insertID + "'; " +
                            "DELETE FROM [USER] WHERE [ID] = '" + txt_insertID + "';";
                        cmd.ExecuteNonQuery();
                        Display_Data();

                        txt_insertID = "";
                        txt_insertPassword = "";
                        txt_insertRole = "";

                        MessageBox.Show("Удалено!");
                    }
                    else
                    {
                        MessageBox.Show("Поля не могут быть пустые!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пользователь не может быть удален, если он забронировал компьютер!");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void Update_Click(object sender) // изменить запись
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    
                    SqlCommand cmdCheck = sqlCon.CreateCommand();
                    cmdCheck.CommandType = CommandType.Text;
                    cmdCheck.CommandText = "SELECT passForgot FROM [USER] WHERE ID = @UserID";
                    cmdCheck.Parameters.AddWithValue("@UserID", txt_insertID); 

                    var passForgotFlag = cmdCheck.ExecuteScalar();

                   
                    if (passForgotFlag != null && (bool)passForgotFlag)
                    {
                       
                        SqlCommand cmdUpdatePassword = sqlCon.CreateCommand();
                        cmdUpdatePassword.CommandType = CommandType.Text;
                        cmdUpdatePassword.CommandText = "UPDATE [USER] SET [Password] = HASHBYTES('SHA2_256',@NewPassword) , [passForgot] = 0 WHERE [ID] = @UserID";
                        cmdUpdatePassword.Parameters.AddWithValue("@NewPassword", txt_insertPassword); 
                        cmdUpdatePassword.Parameters.AddWithValue("@UserID", txt_insertID); 

                        cmdUpdatePassword.ExecuteNonQuery();
                        SendAnnounceToUser(txt_insertID);
                        txt_insertID = "";
                        txt_insertPassword = "";
                        txt_insertRole = "";
                        MessageBox.Show("Пароль успешно обновлен!");
                    }
                    else
                    {
                        MessageBox.Show("Пароль не может быть изменен. Пользователь не имеет разрешения на изменение пароля.");
                    }

                    if (!string.IsNullOrEmpty(txt_insertRole))
                    {
                       
                        SqlCommand cmdUpdateRole = sqlCon.CreateCommand();
                        cmdUpdateRole.CommandType = CommandType.Text;
                        cmdUpdateRole.CommandText = "UPDATE [USER] SET [role] = @NewRole WHERE [ID] = @UserID";
                        cmdUpdateRole.Parameters.AddWithValue("@NewRole", txt_insertRole); 
                        cmdUpdateRole.Parameters.AddWithValue("@UserID", txt_insertID); 

                        cmdUpdateRole.ExecuteNonQuery(); 

                        Display_Data(); 

                        txt_insertID = ""; 
                        txt_insertPassword = "";
                        txt_insertRole = "";

                        MessageBox.Show("Роль успешно обновлена!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении пользователя!");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void SearchLog_Click(object sender)//поиск по логину
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [USER] WHERE ID = '" + txt_SearchID + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridViewUsers.ItemsSource = dt.DefaultView;
                    sqlCon.Close();
                    txt_SearchID = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Отсутствуют данные!");
            }
            finally
            {
                sqlCon.Close();
            }
        }


        #endregion

     

    }
}
