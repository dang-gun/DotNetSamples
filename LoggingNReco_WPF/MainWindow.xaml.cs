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

using LoggingNReco_WPF.Global;
using Microsoft.Extensions.Logging;

namespace LoggingNReco_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GlobalStatic.LoggerFactory_My
                = LoggerFactory.Create(loggingBuilder =>
                {
                    //콘솔 사용시 표시 옵션
                    loggingBuilder.AddSimpleConsole(x => x.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ");
                    loggingBuilder.AddFilter((provider, category, logLevel) =>
                    {
                        return true;
                    });
                });

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogInformation("btnLog_Info 클릭!");
        }
    }
}
