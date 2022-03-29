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
using System.Windows.Threading;

namespace WpfInvokeTest
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

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            Dispatcher.Invoke(DispatcherPriority.Normal
                , new Action(delegate
                {
                    textBox.SelectAll();
                }));
        }

        private void TextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            Dispatcher.BeginInvoke(DispatcherPriority.Normal
                , new Action(delegate
                {
                    textBox.SelectAll();
                }));
        }
    }
}
