using LoggingNReco_Aspnet.Global;
using System.Diagnostics;

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
        var app = builder.Build();
        

        //로거팩토리 백업
        GlobalStatic.LoggerFactory_My 
            = app.Services.GetRequiredService<ILoggerFactory>();
        

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