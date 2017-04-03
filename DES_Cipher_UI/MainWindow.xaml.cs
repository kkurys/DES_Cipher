using Microsoft.Win32;
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

namespace DES_Cipher_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileRB.IsChecked = true;
            encryptRB.IsChecked = true;
        }

        private void input_Checked(object sender, RoutedEventArgs e)
        {
            var _radiobutton = sender as RadioButton;
            if (_radiobutton.Name == "fileRB")
            {
                fileBTN.IsEnabled = true;
            }
            else
            {
                fileBTN.IsEnabled = false;
            }
        }

        private void fileBTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                inputTB.Text = fileDialog.FileName;
            }
        }
    }
}
