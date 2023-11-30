using System;
using System.Windows;
using LoggingNReco_WPF.Global;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace LoggingNReco_WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
/// <remarks>
/// 종속성 주입 : https://executecommands.com/dependency-injection-in-wpf-net-core-csharp/
/// </remarks>
public partial class App : Application
{
    /// <summary>
    /// 서비스 개체
    /// </summary>
    private ServiceProvider serviceProvider;

    public App()
    {
        ServiceCollection services = new ServiceCollection();

        //로깅 주입 및 로그 파일 설정
        services.AddLogging(loggingBuilder
            => loggingBuilder.AddFile("Logs/Log_{0:yyyy}-{0:MM}-{0:dd}.log"
                , fileLoggerOpts =>
                {
                    //파일 출력 이름
                    fileLoggerOpts.FormatLogFileName = fName =>
                    {
                        return String.Format(fName, DateTime.Now);
                    };

                    //메시지 커스텀
                    fileLoggerOpts.FormatLogEntry = (lmMsg) =>
                    {
                        string sLevel = string.Empty;

                        switch (lmMsg.LogLevel)
                        {
                            case LogLevel.Information:
                                sLevel = "Info";
                                break;
                            case LogLevel.Warning:
                                sLevel = "Warn";
                                break;

                            default:
                                sLevel = lmMsg.LogLevel.ToString();
                                break;
                        }

                        return $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {sLevel} [{lmMsg.LogName}] {lmMsg.Message}";
                    };
                })
                //로거 표시 설정
                .AddSimpleConsole(c => c.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ")
                .AddFilter((provider, category, logLevel) =>
                {
                    return true;
                }));

        services.AddSingleton<MainWindow>();
        serviceProvider = services.BuildServiceProvider();



        //로거팩토리 백업
        GlobalStatic.LoggerFactory_My
            = serviceProvider.GetRequiredService<ILoggerFactory>();

    }

    /// <summary>
    /// 프로그램 시작
    /// </summary>
    /// <param name="e"></param>
    protected override void OnStartup(StartupEventArgs e)
    {
        serviceProvider.GetService<MainWindow>()!.Show();

        base.OnStartup(e);
    }

}
