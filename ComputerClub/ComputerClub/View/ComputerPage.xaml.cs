using ComputerClub.Class;
using ComputerClub.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ComputerClub.Wind
{
    /// <summary>
    /// Логика взаимодействия для ComputerPage.xaml
    /// </summary>
    public partial class ComputerPage : Page
    {
        public ComputerViewModel ComputerViewModel;
        public ComputerPage()
        {
            InitializeComponent();
            this.DataContext = ComputerViewModel = new ComputerViewModel();
            ComputerViewModel.dataGridViewUsers1 = this.dataGridViewUsers1;
            ComputerViewModel.Display_Data();
        }

        private void dataGridViewUsers1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridViewUsers1.SelectedItem is DataRowView selectedRow)
            {
                try
                {
                    if (ComputerViewModel != null)
                    {
                        ComputerViewModel.SelectedComputer = new Computer
                        {
                            Id = int.Parse(selectedRow["ИД"].ToString()),
                            Type = selectedRow["Тип"].ToString(),
                            Processor = selectedRow["Процессор"].ToString(),
                            Videocard = selectedRow["Видеокарта"].ToString(),
                            RAM = selectedRow["ОЗУ"].ToString(),
                            CompDesc = selectedRow["Описание"].ToString(),
                            Count = int.Parse(selectedRow["Колличество"].ToString())
                        };
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Выберите компьютер корректно!");
                }
            }
        }
    }
}
