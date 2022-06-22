using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_change_path_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                tb_path.Text = openFileDialog.FileName;
        }

        private void bt_read_Click(object sender, RoutedEventArgs e)
        {
            string path = tb_path.Text;

            if (File.Exists(path))
                using (FileStream fstream = File.OpenRead(path))
                {
                    byte[] buffer = new byte[fstream.Length];
                    fstream.Read(buffer, 0, buffer.Length);
                    tb_output.Text = Encoding.UTF8.GetString(buffer);
                }
            else
                MessageBox.Show("Файл не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}