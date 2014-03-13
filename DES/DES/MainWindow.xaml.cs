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
using DES.Model;

namespace DES
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

        private void cipherButton_Click(object sender, RoutedEventArgs e)
        {
            string plaintext = messagebox.Text;
            string key = keybox.Text;
            bool hex = (bool)hexRadio.IsChecked;
            int round = roundBox.SelectedIndex + 1;
            if (hex)
            {
                plaintext.Substring(0, 16);
                key.Substring(0, 16);
                var des = new DESClass() { Plaintext = plaintext, Key = key };
                des.CipherHex(round);
                workText.Text = string.Format("{0}{1} CipherBytes: {2}",des.Work,Environment.NewLine, des.Ciphertext);
            }
            else
            {
                plaintext.Substring(0, 8);
                key.Substring(0, 8);
                var des = new DESClass() { Plaintext = plaintext, Key = key };
                des.CipherString(round);
                workText.Text = string.Format("{0}{1} CipherBytes: {2}", des.Work, Environment.NewLine, des.Ciphertext);
            }
        }

        private void decipherButton_Click(object sender, RoutedEventArgs e)
        {
            string ciphertext = messagebox.Text;
            string key = keybox.Text;
            bool hex = (bool)hexRadio.IsChecked;
            int round = roundBox.SelectedIndex + 1;
            if (hex)
            {
                ciphertext.Substring(0, 16);
                key.Substring(0, 16);
                var des = new DESClass() { Ciphertext = ciphertext, Key = key };
                des.DecipherHex(round);
                workText.Text = string.Format("{0}{1} PlainBytes: {2}", des.Work, Environment.NewLine, des.Plaintext);
            }
            else
            {
                ciphertext.Substring(0, 8);
                key.Substring(0, 8);
                var des = new DESClass() { Ciphertext = ciphertext, Key = key };
                des.DecipherString(round);
                workText.Text = string.Format("{0}{1} PlainBytes: {2}", des.Work, Environment.NewLine, des.Plaintext);
            }
        }
    }
}
