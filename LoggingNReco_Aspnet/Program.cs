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

        //�α� ���� �� �α� ���� ����
        builder.Services.AddLogging(loggingBuilder
            => loggingBuilder.AddFile("Logs/Log_{0:yyyy}-{0:MM}-{0:dd}.log"
                , fileLoggerOpts =>
                {
                    //���� ��� �̸�
                    fileLoggerOpts.FormatLogFileName = fName =>
                    {
                        return String.Format(fName, DateTime.Now);
                    };

                    //�޽��� Ŀ����
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
        //�ΰ� ǥ�� ����
        builder.Logging
            .AddSimpleConsole(c => c.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ")
            .AddFilter((provider, category, logLevel) =>
            {
                return true;
            });
        var app = builder.Build();
        

        //�ΰ����丮 ���
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


        //���� �ΰŷ� �α� �����
        GlobalStatic.TestLog("������ Program start Run ������");
        app.Run();
    }
}