using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using ComputerClub.ViewModel;
using ComputerClub.Class;

namespace ComputerClub.Wind
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {

        public ServiceViewModel ServiceViewModel;
        public ServicePage()
        {
            InitializeComponent();
            this.DataContext = ServiceViewModel = new ServiceViewModel();
            ServiceViewModel.dataGridViewUsers1 = this.dataGridViewUsers1;
            ServiceViewModel.Display_Data();
        }

        private void dataGridViewUsers1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridViewUsers1.SelectedItem is DataRowView selectedRow)
            {
                try
                {
                    if (ServiceViewModel != null)
                    {
                        ServiceViewModel.SelectedProc = new Procedure
                        {
                            ID = int.Parse(selectedRow["ИД"].ToString()),
                            Name = selectedRow["Название"].ToString(),
                            Price = decimal.Parse(selectedRow["Цена"].ToString()),
                            Durability = TimeSpan.Parse(selectedRow["Длительность"].ToString()),
                            Description = selectedRow["Описание"].ToString(),

                        };
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Выберите тариф корректно!");
                }
            }
        }
    }
}
