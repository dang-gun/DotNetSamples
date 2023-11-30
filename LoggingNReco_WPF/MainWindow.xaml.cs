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
        /// <summary>
		/// 자체 로거 개체
		/// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory">종속성으로 주입된 로거 개체</param>
        public MainWindow(ILogger<MainWindow> loggerFactory)
        {
            this.logger = loggerFactory;

            InitializeComponent();
        }

        #region 로그 MainWindow
        private void btnLog_Info_Click(object sender, RoutedEventArgs e)
        {
            this.logger
                .LogInformation("btnLog_Info 클릭!");
        }

        private void btnLog_Debug_Click(object sender, RoutedEventArgs e)
        {
            this.logger
                .LogInformation("btnLog_Info 클릭!");
        }

        private void btnLog_Warning_Click(object sender, RoutedEventArgs e)
        {
            this.logger
                .LogInformation("btnLog_Info 클릭!");
        }
        #endregion

        #region 로그 GlobalStatic
        private void btnLogGlobal_Info_Click(object sender, RoutedEventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("MainWindow")
                .LogInformation("btnLogGlobal_Info 클릭!");
        }

        private void btnLogGlobal_Debug_Click(object sender, RoutedEventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("MainWindow")
                .LogDebug("btnLogGlobal_Debug 클릭!");
        }

        private void btnLogGlobal_Warning_Click(object sender, RoutedEventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("MainWindow")
                .LogDebug("btnLogGlobal_Warning 클릭!");
        }
        #endregion


    }
}
