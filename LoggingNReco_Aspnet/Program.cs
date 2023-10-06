using LoggingNReco_Aspnet.Global;
using System.Diagnostics;

namespace LoggingNReco_Aspnet;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Logging.SetMinimumLevel(LogLevel.Trace);
        builder.Logging.AddFilter((provider, category, logLevel) =>
        {
            return true;
        });
        var app = builder.Build();
        

        //�ΰ����丮 ���
        GlobalStatic.LoggerFactory 
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