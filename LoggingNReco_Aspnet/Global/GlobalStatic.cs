

using LoggingNReco_DotNetLogging;

namespace LoggingNReco_Aspnet.Global;

/// <summary>
/// 프로그램 전역 변수
/// </summary>
public class GlobalStatic
{
    /// <summary>
    /// 로거 팩토리
    /// </summary>
    public static ILoggerFactory? LoggerFactory_My;

    /// <summary>
    /// 테스트 로그 출력
    /// </summary>
    /// <param name="sMessage"></param>
    public static void TestLog(string sMessage )
    {
        if(null != GlobalStatic.LoggerFactory_My)
        {
            ILogger logger = GlobalStatic.LoggerFactory_My.CreateLogger("GlobalStatic");

            
            logger.LogTrace(sMessage);
            logger.LogDebug(sMessage);
            logger.LogInformation(sMessage);
        }
    }

    /// <summary>
    /// DotNetLogging를 이용한 로거
    /// </summary>
    internal static DotNetLogging Log = new DotNetLogging();
}
