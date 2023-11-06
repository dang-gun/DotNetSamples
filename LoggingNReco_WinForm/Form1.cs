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
                    //콘솔 사용시 표시 옵션
                    loggingBuilder.AddSimpleConsole(x => x.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ");
                    loggingBuilder.AddFilter((provider, category, logLevel) =>
                    {
                        return true;
                    });
                });

            InitializeComponent();
        }

        private void btnLog_Info_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogInformation("btnLog_Info 클릭!");
        }

        private void btnLog_Debug_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogDebug("btnLog_Debug 클릭!");
        }

        private void btnLog_Warning_Click(object sender, EventArgs e)
        {
            GlobalStatic.LoggerFactory_My!
                .CreateLogger("Form1")
                .LogDebug("btnLog_Warning 클릭!");
        }
    }
}