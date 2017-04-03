using DES_Cipher_Logic;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace DES_Cipher_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DES_Cipher _cipher;
        public MainWindow()
        {
            InitializeComponent();
            _cipher = new DES_Cipher();
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
                inputTB.IsEnabled = false;
            }
            else
            {
                fileBTN.IsEnabled = false;
                inputTB.IsEnabled = true;
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
        private void runBTN_Click(object sender, RoutedEventArgs e)
        {
            string _key;
            if (keyAsciiRB.IsChecked == true)
            {
                _key = Common.WordToBytesFromASCII(keyTB.Text);
            }
            else
            {
                _key = Common.WordToBytesFromHEX(keyTB.Text);
            }
            if (fileRB.IsChecked == true)
            {
                string[] input = Common.ReadBlocksFromFile(inputTB.Text);
                string[] results = new string[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    if (encryptRB.IsChecked == true)
                    {
                        results[i] = _cipher.Encrypt(input[i], _key);
                    }
                    else
                    {
                        results[i] = _cipher.Decrypt(input[i], _key);
                    }

                }
            }
            else
            {
                string _input = inputTB.Text;
                string result = "";
                if (inputAsciiRB.IsChecked == true)
                {
                    _input = Common.WordToBytesFromASCII(inputTB.Text);
                }
                else
                {
                    _input = Common.WordToBytesFromHEX(inputTB.Text);
                }
                if (encryptRB.IsChecked == true)
                {
                    result = _cipher.Encrypt(_input, _key);
                }
                else
                {
                    result = _cipher.Decrypt(_input, _key);
                }
                outTB.Text = Common.BytesToHEX(result);
            }
        }
    }
}
