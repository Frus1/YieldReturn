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
using YieldReturn.Classes;

namespace YieldReturn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NumberGenerator _generator;
        public MainWindow()
        {
            InitializeComponent();
            _generator = new NumberGenerator();
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            NumberListBox.Items.Clear();
            int.TryParse(StartTextBox.Text, out int start);
            int.TryParse(EndTextBox.Text, out int end);
            var numbers = _generator.GenerateNumbers(start, end);
            foreach (int number in numbers)
            {
                NumberListBox.Items.Add(number);
                await Task.Delay(500);
            }
            MessageBox.Show("Генерация завершена.");

        }

        private void StartTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            StartTextBox.Clear();
        }

        private void EndTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            EndTextBox.Clear();
        }
    }
}
