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
            if (Universal.IsChecked == true)
            {
                var hg = Parser.UniPars(Link.Text);
                Header.Text = hg[0];
                Content.Text = hg[1];
            }
            if (Lenta.IsChecked == true)
            {
                if (Link.Text.Contains("lenta.ru"))
                {
                    var hg = Parser.LentaPars(Link.Text);
                    Header.Text = hg[0];
                    Content.Text = hg[1];
                }
                else Header.Text = "Введи ссылку lenta.ru";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
