
using LoggingNReco_DotNetLogging;
using Microsoft.Extensions.Logging;

namespace LoggingNReco_WPF.Global;

	public static class GlobalStatic
	{
    /// <summary>
    /// 로거 팩토리
    /// </summary>
    public static ILoggerFactory? LoggerFactory_My { get; set; }

    /// <summary>
    /// 테스트 로그 출력
    /// </summary>
    /// <param name="sMessage"></param>
    public static void LogInfo(string sMessage)
    {
        if (null != LoggerFactory_My)
        {
            ILogger logger = LoggerFactory_My.CreateLogger("GlobalStatic");


            logger.LogTrace(sMessage);
            logger.LogDebug(sMessage);
            logger.LogInformation(sMessage);
        }
    }

    /// <summary>
    /// DotNetLogging를 이용한 로거
    /// </summary>
    internal static DotNetLogging Log 
        = new DotNetLogging(null, true);
}
