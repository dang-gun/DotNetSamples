﻿using System.Diagnostics;
using System.Reflection;

using Microsoft.Extensions.Logging;

using NReco.Logging.File;


namespace LoggingNReco_DotNetLogging;

/// <summary>
/// 공유 로거Shared logger
/// </summary>
/// <remarks>
/// https://stackoverflow.com/questions/48676152/asp-net-core-web-api-logging-from-a-static-class
/// </remarks>
public class DotNetLogging
{

    /// <summary>
    /// 로거 팩토리
    /// </summary>
    public ILoggerFactory LoggerFactory_My { get; set; }

#pragma warning disable CS8618
    /// <summary>
    /// 기본 생성
    /// <para>로거를 초기화를 하지 않으므로 임시 생성일때만 사용한다.</para>
    /// </summary>
    public DotNetLogging()
    {
        this.LoggerFactory_My = new LoggerFactory();
    }

    /// <summary>
    /// 로거는 자동 생성하고 로거를 기본 옵션으로 초기화 한다.
    /// </summary>
    /// <param name="sPathFormat">로그 파일을 생성할 경로 포맷</param>
    /// <param name="bConsole">콘솔 표시 여부</param>
    public DotNetLogging(
        string? sPathFormat
        , bool bConsole)
    {
        this.Initialize(null, sPathFormat, bConsole);
    }

    /// <summary>
    /// 전달받은 ILoggerFactory개체를 이용하여 로거를 초기화한다.
    /// <para>null이면 기본 옵션으로 새로 생성한다.</para>
    /// </summary>
    /// <remarks>
    /// 자동 생성시 NReco.Logging.File를 기준으로 작성된다.
    /// </remarks>
    /// <param name="loggerFactory">생성한 ILoggerFactory 개채. null이면 자동생성</param>
    /// <param name="sPathFormat">로그 파일을 생성할 경로 포맷</param>
    /// <param name="bConsole">콘솔 표시 여부</param>
    public DotNetLogging(
        ILoggerFactory? loggerFactory
        , string? sPathFormat
        , bool bConsole)
    {
        this.Initialize(loggerFactory, sPathFormat, bConsole);
    }
#pragma warning restore CS8618

    /// <summary>
    /// 이 개체를 초기화 한다.
    /// </summary>
    /// <remarks>
    /// 사용하는 프로젝트가 Microsoft.Extensions.Logging를 참조하고 있어야 한다.
    /// (누겟에서 설치 가능)
    /// </remarks>
    /// <param name="loggerFactory"></param>
    /// <param name="sPathFormat"></param>
    /// <param name="bConsole"></param>
    public void Initialize(
        ILoggerFactory? loggerFactory
        , string? sPathFormat
        , bool bConsole)
    {
        if (null != loggerFactory)
        {
            this.LoggerFactory_My = loggerFactory;
        }
        else
        {
            if (null == sPathFormat)
            {
                //https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-5.0#non-host-console-app
                this.LoggerFactory_My
                    = LoggerFactory.Create(
                        loggingBuilder => DotNetLogging.configure(loggingBuilder, bConsole));
            }
            else
            {
                this.LoggerFactory_My
                    = LoggerFactory.Create(
                        loggingBuilder => DotNetLogging.configure(loggingBuilder, sPathFormat, bConsole));
            }
        }
    }

    /// <summary>
    /// 미리 세팅된 기본 옵션으로 로거를 생성한다.
    /// <para>파일 경로도 기본 세팅된 것을 기준으로 사용한다.</para>
    /// </summary>
    /// <param name="loggingBuilder"></param>
    /// <param name="bConsole">콘솔 표시 여부</param>
    /// <returns></returns>
    public static ILoggingBuilder configure(
        ILoggingBuilder loggingBuilder
        , bool bConsole)
    {
        return configure(
            loggingBuilder
            , Path.Combine("Logs", "Log_{0:yyyy}-{0:MM}-{0:dd}.log")
            , bConsole);
    }

    /// <summary>
    /// 미리 세팅된 기본 옵션으로 로거를 생성한다.
    /// </summary>
    /// <param name="loggingBuilder"></param>
    /// <param name="sPathFormat">로그 파일을 생성할 경로 포맷</param>
    /// <param name="bConsole">콘솔 표시 여부</param>
    /// <returns></returns>
    public static ILoggingBuilder configure(
        ILoggingBuilder loggingBuilder
        , string sPathFormat
        , bool bConsole)
    {
        if (true == bConsole)
        {//콘솔 사용
            loggingBuilder.AddSimpleConsole(x => x.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ");
            //loggingBuilder.AddSimpleConsole(x=>x.TimestampFormat)
        }

        //로거 표시 설정(디버거 등의 메시지 출력 설정)
        loggingBuilder.AddFilter(
            (provider, category, logLevel) =>
            {
                return true;
            });

        loggingBuilder.AddFile(sPathFormat
            , fileLoggerOpts =>
            {
                fileLoggerOpts.FormatLogFileName = sNameFormat =>
                {
                    return String.Format(sNameFormat, DateTime.Now);
                };

                fileLoggerOpts.FormatLogEntry = (lmMsg) =>
                {
                    //string sLevel = string.Empty;

                    //switch (lmMsg.LogLevel)
                    //{
                    //    case LogLevel.Information:
                    //        sLevel = "Info";
                    //        break;
                    //    case LogLevel.Warning:
                    //        sLevel = "Warn";
                    //        break;

                    //    default:
                    //        sLevel = lmMsg.LogLevel.ToString();
                    //        break;
                    //}

                    return $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {lmMsg.LogLevel} [{lmMsg.LogName}] {lmMsg.Message}";
                };

            });

        return loggingBuilder;
    }

    /// <summary>
    /// 개체를 전달하여 로거 생성
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public ILogger CreateLogger<T>() => LoggerFactory_My.CreateLogger<T>();
    /// <summary>
    /// 카테고리이름을 직접 입력하여 로거 생성
    /// </summary>
    /// <param name="sCategoryName"></param>
    /// <returns></returns>
    public ILogger CreateLogger(string sCategoryName)
        => LoggerFactory_My.CreateLogger(sCategoryName);

    /// <summary>
    /// 호출한 클래스를 찾아 카테고리 이름으로 출력한다.
    /// </summary>
    /// <returns>없으면 빈값</returns>
    private string CategoryName()
    {
        string sReturn = string.Empty;
        //= new StackTrace().GetFrame(2).GetMethod().ReflectedType.Name;

        StackTrace stTemp = new StackTrace();
        StackFrame? sfTemp = stTemp.GetFrame(2);

        if (null != sfTemp)
        {
            MethodBase? mbTemp = sfTemp.GetMethod();

            if (null != mbTemp)
            {
                Type? typeTemp = mbTemp.ReflectedType;
                if (null != mbTemp)
                {
                    sReturn = mbTemp.Name;
                }
            }
        }

        return sReturn;
    }


    /// <summary>
    /// 정보 로그로 출력
    /// </summary>
    /// <param name="sMessage"></param>
    public void LogInfo(string sMessage)
    {
        this.LogInfo(this.CategoryName(), sMessage);
    }
    /// <summary>
    /// 정보 로그로 출력
    /// </summary>
    /// <param name="sCategoryName"></param>
    /// <param name="sMessage"></param>
    public void LogInfo(
        string sCategoryName
        , string sMessage)
    {
        this.LoggerFactory_My
            .CreateLogger(sCategoryName)
            .LogInformation(sMessage);
    }

    /// <summary>
    /// 에러 로그로 출력
    /// </summary>
    /// <param name="ex"></param>
    public void LogError(Exception ex)
    {
        this.LogError(ex.ToString());
    }
    /// <summary>
    /// 에러 로그로 출력
    /// </summary>
    /// <param name="sMessage"></param>
    public void LogError(string sMessage)
    {
        this.LogError(this.CategoryName(), sMessage);
    }
    /// <summary>
    /// 에러 로그로 출력
    /// </summary>
    /// <param name="sCategoryName"></param>
    /// <param name="sMessage"></param>
    public void LogError(
        string sCategoryName
        , string sMessage)
    {
        this.LoggerFactory_My
            .CreateLogger(sCategoryName)
            .LogError(sMessage);
    }


    /// <summary>
    /// 디버그 로그 출력
    /// </summary>
    /// <param name="sMessage"></param>
    public void LogDebug(string sMessage)
    {
        this.LogDebug(this.CategoryName(), sMessage);
    }
    /// <summary>
    /// 디버그 로그 출력
    /// </summary>
    /// <param name="sCategoryName"></param>
    /// <param name="sMessage"></param>
    public void LogDebug(
        string sCategoryName
        , string sMessage)
    {
        this.LoggerFactory_My
            .CreateLogger(sCategoryName)
            .LogDebug(sMessage);
    }



    /// <summary>
    /// 경고 로그 출력
    /// </summary>
    /// <param name="sMessage"></param>
    public void LogWarning(string sMessage)
    {
        this.LogWarning(this.CategoryName(), sMessage);
    }
    /// <summary>
    /// 경고 로그 출력
    /// </summary>
    /// <param name="sCategoryName"></param>
    /// <param name="sMessage"></param>
    public void LogWarning(
        string sCategoryName
        , string sMessage)
    {
        this.LoggerFactory_My
            .CreateLogger(sCategoryName)
            .LogWarning(sMessage);
    }

    /// <summary>
    /// 심각 로그 출력
    /// </summary>
    /// <param name="sMessage"></param>
    public void LogCritical(string sMessage)
    {
        this.LogCritical(this.CategoryName(), sMessage);
    }
    /// <summary>
    /// 심각 로그 출력
    /// </summary>
    /// <param name="sCategoryName"></param>
    /// <param name="sMessage"></param>
    public void LogCritical(
        string sCategoryName
        , string sMessage)
    {
        this.LoggerFactory_My
            .CreateLogger(sCategoryName)
            .LogCritical(sMessage);
    }
}

