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
    public class AdminViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _durab;
        private string _prName;
        private string _price;
        private string _description;

        public string Name
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string durab
        {
            get => _durab;
            set
            {
                _durab = value;
                OnPropertyChanged();
            }
        }

        public string namePr
        {
            get => _prName;
            set
            {
                _prName = value;
                OnPropertyChanged();
            }
        }

        public string pricePr
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        public string descriptionPr
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _type;
        private string _proc;
        private string _vc;
        private string _ram;
        private string _desc;
        private string _count;


        public string txt_count { get => _count; set { _count = value; OnPropertyChanged(); } }
        public string txt_regType { get => _type; set { _type = value; OnPropertyChanged(); } }
        public string txt_proc { get => _proc; set { _proc = value; OnPropertyChanged(); } }
        public string txt_videocard { get => _vc; set { _vc = value; OnPropertyChanged(); } }
        public string txt_ram { get => _ram; set { _ram = value; OnPropertyChanged(); } }
        public string txt_desc { get => _desc; set { _desc = value; OnPropertyChanged(); } }


        public Frame AdFrameNavigation { get; set; }
        public Frame AdFrameNavigation2 { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\DataBase\stm.mdf';Integrated Security=True;Connect Timeout=30");
        public Window wind { get; set; }

        public ICommand AdminClose {  get; }

        public ICommand ChangeAcc { get; }

        public ICommand MinimizeWin { get; }

        public ICommand HelpBtn { get; }

        public ICommand AboutBtn { get; }

        public ICommand TimetableBtn { get; }

        public ICommand ClientBtn { get; }
        public ICommand ClientPanelBtn { get; }
        public ICommand ComputerBtn { get; }

        public ICommand HomePageBtn { get; }

        public ICommand RegProcCommand { get; }

        public ICommand ServiceCommand { get; }
        public ICommand InsertComputerCommand { get; }


        public AdminViewModel(string name,Window window)
        {
            Name = name;
            this.wind = window;

            AdminClose = new RelayCommand(AdminClose_Click);
            ChangeAcc = new RelayCommand(ChangeAcc_Click);
            MinimizeWin = new RelayCommand(MinimizedWin_CLick);
            HelpBtn = new RelayCommand(HelpBut_Click);
            AboutBtn = new RelayCommand(AboutBtn_Click);
            TimetableBtn = new RelayCommand(Timetable_CLick);
            ClientBtn = new RelayCommand(Client_Click);
            ClientPanelBtn = new RelayCommand(ClientsPanel_Click);
            ComputerBtn = new RelayCommand(Computer_Click);
            HomePageBtn = new RelayCommand(HomePage_Click);
            RegProcCommand = new RelayCommand(RegestrPriem_Click);
            ServiceCommand = new RelayCommand(Service_Click);
            InsertComputerCommand = new RelayCommand(InsertComputer_Click);

        }


        #region =Меню=


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

        private void MinimizedWin_CLick(object sender)//кнопка свернуть окно
        {
            wind.WindowState = WindowState.Minimized;
        }

        #endregion

        #region=PopUp=

        private void HelpBut_Click(object sender)//кнопка помощь в pop up
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void AboutBtn_Click(object sender)
        {

            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
        #endregion

        #region=MainButtons=
        private void Timetable_CLick(object sender)//кнопка вызова расписания
        {
            AdFrameNavigation2.Visibility = Visibility.Visible;

            AdFrameNavigation.Content = new TimetablePage();
            AdFrameNavigation2.Content = new PersonPage();
        }

        private void Client_Click(object sender)//кнопка перехода на клиенты страницу
        {
            AdFrameNavigation.Content = new PersonPage();
            AdFrameNavigation2.Visibility = Visibility.Collapsed;

        }

        private void Service_Click(object sender)//кнопка перехода на страницу с услугами
        {
            AdFrameNavigation.Content = new ServicePage();
            AdFrameNavigation2.Visibility = Visibility.Collapsed;

        }

        private void ClientsPanel_Click(object sender)
        {
            ModerWindow moderWindow = new ModerWindow();
            moderWindow.ShowDialog();
        }

        private void Computer_Click(object sender)
        {
            AdFrameNavigation.Content = new ComputerPage();
            AdFrameNavigation2.Visibility = Visibility.Collapsed;



        }

        private void HomePage_Click(object sender)//кнопка перехода на главную страницу
        {
            AdFrameNavigation.Content = new HomePage();
            AdFrameNavigation2.Visibility = Visibility.Collapsed;

        }
        #endregion


        TimeSpan Conver(string durab)
        {
            TimeSpan timedurab = new TimeSpan(0, 0, 0);
            switch (durab)
            {
                case "10 мин":
                    timedurab = new TimeSpan(0, 10, 0);
                    break;
                case "20 мин":
                    timedurab = new TimeSpan(0, 20, 0);
                    break;
                case "30 мин":
                    timedurab = new TimeSpan(0, 30, 0);
                    break;
                case "40 мин":
                    timedurab = new TimeSpan(0, 40, 0);
                    break;
                case "50 мин":
                    timedurab = new TimeSpan(0, 50, 0);
                    break;
                case "60 мин":
                    timedurab = new TimeSpan(1, 0, 0);
                    break;
                case "90 мин":
                    timedurab = new TimeSpan(1, 30, 0);
                    break;
                case "120 мин":
                    timedurab = new TimeSpan(2, 0, 0);
                    break;
                case "180 мин":
                    timedurab = new TimeSpan(3, 0, 0);
                    break;
                case "240 мин":
                    timedurab = new TimeSpan(4, 0, 0);
                    break;
                case "300 мин":
                    timedurab = new TimeSpan(5, 0, 0);
                    break;
                case "360 мин":
                    timedurab = new TimeSpan(6, 0, 0);
                    break;
                default:
                    timedurab = new TimeSpan(0, 30, 0);
                    break;
            }
            return timedurab;
        }


        public bool IsTimeSlotOccupied()
        {
            bool isOccupied = false;

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                string query = @"SELECT COUNT(*) 
                         FROM [PROCEDURE_INFO] 
                         WHERE [Procedure] = @ProcName "
                ;

                SqlCommand command = new SqlCommand(query, sqlCon);
                command.Parameters.AddWithValue("@ProcName", namePr);

                int count = Convert.ToInt32(command.ExecuteScalar());
                isOccupied = count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка проверки: {"Ошибка при работе с БД!"}");
            }
            finally
            {
                sqlCon.Close();
            }

            return isOccupied;
        }


        private void RegestrPriem_Click(object sender)//кнопка регестрации тарифа
        {
            try
            {

                if (IsTimeSlotOccupied())
                {
                    MessageBox.Show("Выбранный тариф уже занят. Выберите другое название.");
                    return;
                }
                if(string.IsNullOrEmpty(namePr) || string.IsNullOrEmpty(pricePr) || string.IsNullOrEmpty(descriptionPr) || string.IsNullOrEmpty(durab) )
                {
                    MessageBox.Show("Введите все данные корректно!");
                    return;
                }
                if (int.Parse(pricePr) <= 0)
                {
                    MessageBox.Show("Введите все данные корректно!");
                    return;
                }
                if(namePr.Length > 30)
                {
                    MessageBox.Show("Длина не может быть больше 30!");
                    return;
                }


                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String quer = "INSERT INTO [PROCEDURE_INFO] ([Durability], [Procedure], [Price], [Description]) values (@durab, @proced, @price, @descrep)";
                SqlCommand cmd = new SqlCommand(quer, sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@durab", Conver(durab));
                cmd.Parameters.AddWithValue("@proced", namePr);
                cmd.Parameters.AddWithValue("@price", pricePr);
                cmd.Parameters.AddWithValue("@descrep", descriptionPr);
                cmd.ExecuteNonQuery();

                durab = "";
                namePr = "";
                pricePr = "";
                descriptionPr = "";

                MessageBox.Show("Занесено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Данные введены не корректно!");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        #region =Computer=
        private void InsertComputer_Click(object sender)//добавление компа
        {
            try
            {
                int count;
                if (sqlCon.State == ConnectionState.Closed)
                {
                    if (txt_regType != "" && txt_proc != "" && txt_ram != "" && txt_videocard != "" && txt_count != "" && Int32.TryParse(txt_count, out count))//проверка на пустые строки and int
                    {
                        if (count > 15 || count < 0)
                        {
                            MessageBox.Show("Кол-во не может быть >15 и <0");
                            txt_count = "";
                            return;

                        }
                        sqlCon.Open();



                        String quer2 = "INSERT INTO [COMPUTER_INFO]  values (@type, @proc, @videocard, @ram, @desc,@count)";
                        SqlCommand cmd2 = new SqlCommand(quer2, sqlCon);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.AddWithValue("@type", txt_regType);
                        cmd2.Parameters.AddWithValue("@proc", txt_proc);
                        cmd2.Parameters.AddWithValue("@videocard", txt_videocard);
                        cmd2.Parameters.AddWithValue("@ram", txt_ram);
                        cmd2.Parameters.AddWithValue("@desc", txt_desc);
                        cmd2.Parameters.AddWithValue("@count", txt_count);

                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Congrulation!");
                        sqlCon.Close();

                        txt_regType = "";
                        txt_proc = "";
                        txt_ram = "";
                        txt_videocard = "";
                        txt_desc = "";
                        txt_count = "";
                    }
                    else
                    {
                        MessageBox.Show("Все поля доджны быть заполнены!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат данных!");
            }
            finally
            {
                sqlCon.Close();
            }
        }
        #endregion
    }
}
