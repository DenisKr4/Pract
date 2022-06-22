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
using System.IO.IsolatedStorage;
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uColor.ReadFromIsolatedStorage();
            uColor.ChangeColorLabel(lb_color);
        }
        
        UserColor uColor = new UserColor();
        private class UserColor
        {
            private Color _userColor;
            public Color userColor { get { return _userColor; } set { _userColor = value; } }
            private IsolatedStorageFile _userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            private const string path = @"color.txt";

            public SolidColorBrush GetBrush()
            {
                return new SolidColorBrush(_userColor);
            }
            public void ReadFromIsolatedStorage()
            {
                if (!_userStorage.FileExists(path))
                {
                    _userStorage.CreateFile(path);
                    return;
                }

                IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(path, FileMode.Open, _userStorage);
                StreamReader userReader = new StreamReader(userStream);
                _userColor = (Color)ColorConverter.ConvertFromString(userReader.ReadToEnd());
                userReader.Close();
            }

            public void SaveInIsolatedStorage()
            {
                if (_userStorage.FileExists(path))
                    _userStorage.DeleteFile(path);

                _userStorage.CreateFile(path).Close();
                IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(path, FileMode.Open, _userStorage);
                StreamWriter userWriter = new StreamWriter(userStream);
                string test1 = _userColor.ToString();
                userWriter.Write(_userColor.ToString());
                userWriter.Close();
            }

            public void ChangeColorLabel(Label lb)
            {
                lb.Background = new SolidColorBrush(_userColor);
                lb.Content = _userColor.ToString();
            }
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            uColor.SaveInIsolatedStorage();
        }

        private void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            uColor.userColor = colorPicker.SelectedColor.Value;
            uColor.ChangeColorLabel(lb_color);
        }
    }
}
