using LoggingNReco_WinForm.Global;
using Microsoft.Extensions.Logging;

namespace LoggingNReco_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            GlobalStatic.LoggerFactory_My
                = LoggerFactory.Create(loggingBuilder =>
                {
                    //�ܼ� ���� ǥ�� �ɼ�
                    loggingBuilder.AddSimpleConsole(x => x.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ");
                    loggingBuilder.AddFilter((provider, category, logLevel) =>
                    {
                        return true;
                    });

                    //���� ���
                    loggingBuilder.AddFile("Logs/Log_{0:yyyy}-{0:MM}-{0:dd}.log"
                        , fileLoggerOpts =>
                        {
                            //���� ��� �̸�
                            fileLoggerOpts.FormatLogFileName = sNameFormat =>
                            {
                                return String.Format(sNameFormat, DateTime.Now);
                            };
                        });
                });

            InitializeComponent();
        }

        private void btnLog_Info_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogInformation("btnLog_Info Ŭ��!");
        }

        private void btnLog_Debug_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogDebug("btnLog_Debug Ŭ��!");
        }

        private void btnLog_Warning_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogDebug("btnLog_Warning Ŭ��!");
        }
    }
}