using Microsoft.Extensions.Logging;

using NReco.Logging.File;

using LoggingNReco_WinForm.Global;



namespace LoggingNReco_WinForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 자체 로거 개체
        /// </summary>
        private ILogger logger;

        public Form1()
        {
            GlobalStatic.LoggerFactory_My
                = LoggerFactory.Create(loggingBuilder =>
                {
                    //파일 출력
                    loggingBuilder.AddFile("Logs/LogFrom_{0:yyyy}-{0:MM}-{0:dd}.log"
                        , fileLoggerOpts =>
                        {
                            //파일 출력 이름
                            fileLoggerOpts.FormatLogFileName = sNameFormat =>
                            {
                                return String.Format(sNameFormat, DateTime.Now);
                            };
                        });

                    //콘솔 사용시 표시 옵션
                    loggingBuilder.AddSimpleConsole(x => x.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ");
                    loggingBuilder.AddFilter((provider, category, logLevel) =>
                    {
                        return true;
                    });
                });

            //이 클래스 로거 설정
            this.logger = GlobalStatic.LoggerFactory_My
                            .CreateLogger("Form1");

            InitializeComponent();
        }

        #region Form log - Form1
        private void btnLog_Info_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation("btnLog_Info 클릭!");
        }

        private void btnLog_Debug_Click(object sender, EventArgs e)
        {
            this.logger.LogDebug("btnLog_Debug 클릭!");
        }

        private void btnLog_Warning_Click(object sender, EventArgs e)
        {
            this.logger.LogDebug("btnLog_Warning 클릭!");
        }
        #endregion

        #region Form log - GlobalStatic
        private void btnLogGlobal_Info_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogInformation("btnLogGlobal_Info 클릭!");
        }

        private void btnLogGlobal_Debug_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogDebug("btnLogGlobal_Debug 클릭!");
        }

        private void btnLogGlobal_Warning_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogDebug("btnLogGlobal_Warning 클릭!");
        }
        #endregion

        #region DotNetLogging - GlobalStatic
        private void btnDotNetLogging_Form_Info_Click(object sender, EventArgs e)
        {
            GlobalStatic.Log.LogInfo("btnDotNetLogging_Form_Info 클릭!");
        }

        private void btnDotNetLogging_Form_Debug_Click(object sender, EventArgs e)
        {
            GlobalStatic.Log.LogDebug("btnDotNetLogging_Form_Debug 클릭!");
        }

        private void btnDotNetLogging_Form_Warning_Click(object sender, EventArgs e)
        {
            GlobalStatic.Log.LogWarning("btnDotNetLogging_Form_Warning 클릭!");
        }
        #endregion

        #region DotNetLogging - GlobalStatic
        private void btnDotNetLogging_GlobalStatic_Info_Click(object sender, EventArgs e)
        {
            GlobalStatic.LogGs_Info("btnDotNetLogging_GlobalStatic_Info 클릭!");
        }

        private void btnDotNetLogging_GlobalStatic_Debug_Click(object sender, EventArgs e)
        {
            GlobalStatic.LogGs_Debug("btnDotNetLogging_GlobalStatic_Debug 클릭!");
        }

        private void btnDotNetLogging_GlobalStatic_Warning_Click(object sender, EventArgs e)
        {
            GlobalStatic.LogGs_Warning("btnDotNetLogging_GlobalStatic_Warning 클릭!");
        }
        #endregion



        private void btnLog_AnotherFile_Click(object sender, EventArgs e)
        {
            GlobalStatic.Log_AnotherFile.LogInfo("다른 파일 - 정보");
            GlobalStatic.Log_AnotherFile.LogDebug("다른 파일 - 디버그");
            GlobalStatic.Log_AnotherFile.LogWarning("다른 파일 - 경고");
        }
    }
}