using Microsoft.Win32;
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

namespace Wpfparser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Link.GotFocus += Link_GotFocus;
        }

        private void Link_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Clipboard.GetText().Contains("http"))
            {
                Link.Text = Clipboard.GetText();
            }
            else if (Link.Text.Equals("Введите ссылку")) Link.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var hc = Parser.UniParse(Link.Text);
            Header.Text = hc[0];
            Content.Text = hc[1];
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (Content.Text == "") MessageBox.Show("Нажми вывод");
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text file (*.txt)|*.txt";
                saveFileDialog.FileName = "Сайт";
                if (saveFileDialog.ShowDialog() == true)
                    File.WriteAllText(saveFileDialog.FileName, Link.Text + "\n" + "\n" + Header.Text + "\n" + "\n" + Content.Text);
            }
        }
    }
}
