﻿using Microsoft.Extensions.Logging;

using LoggingNReco_DotNetLogging;


namespace LoggingNReco_WinForm.Global;

	public static class GlobalStatic
	{
    /// <summary>
    /// 로거 팩토리
    /// </summary>
    public static ILoggerFactory? LoggerFactory_My { get; set; }

    /// <summary>
    /// 정보 로그 출력
    /// </summary>
    /// <param name="sMessage"></param>
    public static void LogTest(string sMessage)
    {
        if (null != LoggerFactory_My)
        {
            ILogger logger = LoggerFactory_My.CreateLogger("GlobalStatic");

            logger.LogTrace(sMessage);
            logger.LogInformation(sMessage);
            logger.LogDebug(sMessage);
            logger.LogWarning(sMessage);
        }
    }
    
    /// <summary>
    /// DotNetLogging를 이용한 로거
    /// </summary>
    internal static DotNetLogging Log = new DotNetLogging(null, true);

    public static void LogGs_Info(string sMessage)
    {
        Log.LogInfo(sMessage);
    }
    public static void LogGs_Debug(string sMessage)
    {
        Log.LogDebug(sMessage);
    }
    public static void LogGs_Warning(string sMessage)
    {
        Log.LogWarning(sMessage);
    }

    /// <summary>
    /// 다른 파일 로거
    /// </summary>
    internal static DotNetLogging Log_AnotherFile 
        = new DotNetLogging(
            Path.Combine("Logs", "LogAnotherFile_{0:yyyy}-{0:MM}-{0:dd}.log")
            , true);
}
