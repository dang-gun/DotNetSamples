
namespace LoggingNReco_Aspnet.Global;

/// <summary>
/// 프로그램 전역 변수
/// </summary>
public class GlobalStatic
{
    /// <summary>
    /// 로거 팩토리
    /// </summary>
    public static ILoggerFactory? LoggerFactory;

    /// <summary>
    /// 테스트 로그 출력
    /// </summary>
    /// <param name="sMessage"></param>
    public static void TestLog(string sMessage )
    {
        if(null != GlobalStatic.LoggerFactory)
        {
            ILogger logger = GlobalStatic.LoggerFactory.CreateLogger("GlobalStatic");

            
            logger.LogTrace(sMessage);
            logger.LogDebug(sMessage);
            logger.LogInformation(sMessage);
        }

        
    }
}
