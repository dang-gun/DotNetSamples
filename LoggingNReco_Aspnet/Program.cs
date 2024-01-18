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

        //���Ӽ� ������ ��� ó������ ����
        //true = DotNetLogging�� �̿��ϴ� ���
        //false = ���Ӽ� ������ ���� �� ���
        bool bLogger = false;

        if(bLogger)
        {//���Ӽ� ������ ���� �� ���


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
        }
        else
        {//DotNetLogging�� �̿��ϴ� ���

            //�α� ���� �� �α� ���� ����
            builder.Services.AddLogging(loggingBuilder
                => DotNetLogging.configure(loggingBuilder, true));
        }

        

        var app = builder.Build();

        //���� �����ϴ� ���
        //�ΰ����丮 ���
        GlobalStatic.LoggerFactory_My
            = app.Services.GetRequiredService<ILoggerFactory>();

        if (false == bLogger)
        {//DotNetLogging�� �̿��ϴ� ���

            //������ �ΰ����丮�� �����Ͽ� DotNetLogging�� �ٽ� �����Ѵ�.
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


        //���� �ΰŷ� �α� �����
        GlobalStatic.TestLog("������ Program start Run ������");
        app.Run();
    }
}