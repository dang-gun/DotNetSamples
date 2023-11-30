using LoggingNReco_WinForm.Global;
using Microsoft.Extensions.Logging;

namespace LoggingNReco_WinForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ��ü �ΰ� ��ü
        /// </summary>
        private ILogger logger;

        public Form1()
        {
            GlobalStatic.LoggerFactory_My
                = LoggerFactory.Create(loggingBuilder =>
                {
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

                    //�ܼ� ���� ǥ�� �ɼ�
                    loggingBuilder.AddSimpleConsole(x => x.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ");
                    loggingBuilder.AddFilter((provider, category, logLevel) =>
                    {
                        return true;
                    });
                });

            //�� Ŭ���� �ΰ� ����
            this.logger = GlobalStatic.LoggerFactory_My
                            .CreateLogger("Form1");

            InitializeComponent();
        }

        #region �α� Form1
        private void btnLog_Info_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation("btnLog_Info Ŭ��!");
        }

        private void btnLog_Debug_Click(object sender, EventArgs e)
        {
            this.logger.LogDebug("btnLog_Debug Ŭ��!");
        }

        private void btnLog_Warning_Click(object sender, EventArgs e)
        {
            this.logger.LogDebug("btnLog_Warning Ŭ��!");
        }
        #endregion

        #region �α� GlobalStatic
        private void btnLogGlobal_Info_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogInformation("btnLogGlobal_Info Ŭ��!");
        }

        private void btnLogGlobal_Debug_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogDebug("btnLogGlobal_Debug Ŭ��!");
        }

        private void btnLogGlobal_Warning_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogDebug("btnLogGlobal_Warning Ŭ��!");
        }
        #endregion
    }
}