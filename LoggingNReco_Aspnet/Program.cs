using System.Diagnostics;

using NReco.Logging.File;

using LoggingNReco_Aspnet.Global;
using LoggingNReco_DotNetLogging;



namespace LoggingNReco_Aspnet;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder 
            = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //종속성 주입을 어떻게 처리할지 여부
        //true = DotNetLogging를 이용하는 경우
        //false = 종속성 주입을 직접 할 경우
        bool bLogger = false;

        if(bLogger)
        {//종속성 주입을 직접 할 경우


            //로깅 주입 및 로그 파일 설정
            builder.Services.AddLogging(loggingBuilder
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
                    }));



            //builder.Logging.SetMinimumLevel(LogLevel.Trace);
            //로거 표시 설정
            builder.Logging
                .AddSimpleConsole(c => c.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ")
                .AddFilter((provider, category, logLevel) =>
                {
                    return true;
                });
        }
        else
        {//DotNetLogging를 이용하는 경우

            //로깅 주입 및 로그 파일 설정
            builder.Services.AddLogging(loggingBuilder
                => DotNetLogging.configure(loggingBuilder, true));
        }

        

        var app = builder.Build();

        //직접 주입하는 경우
        //로거팩토리 백업
        GlobalStatic.LoggerFactory_My
            = app.Services.GetRequiredService<ILoggerFactory>();

        if (false == bLogger)
        {//DotNetLogging를 이용하는 경우

            //생성한 로거팩토리를 전달하여 DotNetLogging를 다시 생성한다.
            GlobalStatic.Log
                = new DotNetLogging(
                    app.Services.GetRequiredService<ILoggerFactory>()
                    , true);
        }
        

            
        

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();


        //전역 로거로 로그 남기기
        GlobalStatic.TestLog("♡♡♡ Program start Run ♡♡♡");
        app.Run();
    }
}