using System.Text;
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

namespace CrossThreadTest_WPF
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

        private void btnCrossThread_Error_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                this.labCrossThread_TestText.Content = "크로스 쓰래드 에러가 납니다.";
            }).Start();
        }

        private void btnNoneError_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                this.Dispatcher.Invoke(
                    new Action(delegate()
                    {
                        this.labCrossThread_TestText.Content
                            = "크로스 쓰래드 에러가 안 납니다.";
                    }));
            }).Start();

            //new Thread(() =>
            //{
            //    Dispatcher.Invoke(DispatcherPriority.Normal
            //        , new Action(delegate
            //        {
            //            this.labCrossThread_TestText.Content
            //                = "크로스 쓰래드 에러가 안 납니다.";
            //        }));
            //}).Start();
        }

        private void btnGlobal_Out_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                GlobalStatic.CrossThread_WPF(
                    this
                    , () =>
                    {
                        this.labCrossThread_TestText.Content 
                            = "공통화 함수 - 외부 스레드";
                    });

            }).Start();
            
        }

        private void btnGlobal_This_Click(object sender, RoutedEventArgs e)
        {
            GlobalStatic.CrossThread_WPF(
                this
                , () =>
                {
                    this.labCrossThread_TestText.Content
                        = "공통화 함수 - 자기 스레드";
                });
        }
    }
}