using EfMultiMigrations;
using EfMultiMigrations.Models;
using Microsoft.EntityFrameworkCore;
using ModelsDB;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


//설정 파일 읽기
string sJson = File.ReadAllText("SettingInfo_gitignore.json");
SettingInfoModel? loadSetting = JsonConvert.DeserializeObject<SettingInfoModel>(sJson);


// Add services to the container.

ModelDllGlobal.DbType = TargetDbType.Sqlite;
//ModelDllGlobal.DbType = TargetDbType.Mssql;

switch (ModelDllGlobal.DbType)
{
	case TargetDbType.Sqlite:
		//Add-Migration InitialCreate -Context ModelsDB.DbModel_SqliteContext -OutputDir Migrations/Sqlite
		ModelDllGlobal.DbConnectString
			= "Data Source=Test.db";

		using (DbModel_SqliteContext db1 = new DbModel_SqliteContext())
		{
			db1.Database.Migrate();
		}
		break;

	case TargetDbType.Mssql:
		//Add-Migration InitialCreate -Context ModelsDB.DbModel_MssqlContext -OutputDir Migrations/Mssql
		//Update-Database -Context ModelsDB.DbModel_MssqlContext -Migration 0	
		//Remove-Migration -Context ModelsDB.DbModel_MssqlContext
		//ModelDllGlobal.DbConnectString = "Server=[주소];DataBase=[데이터 베이스];UId=[아이디];pwd=[비밀번호]";
		ModelDllGlobal.DbConnectString = loadSetting!.ConnectionString_Mssql;

		using (DbModel_MssqlContext db2 = new DbModel_MssqlContext())
		{
			db2.Database.Migrate();
		}
		break;
}





	var app = builder.Build();

// Configure the HTTP request pipeline.

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
	var forecast = Enumerable.Range(1, 5).Select(index =>
		new WeatherForecast
		(
			DateTime.Now.AddDays(index),
			Random.Shared.Next(-20, 55),
			summaries[Random.Shared.Next(summaries.Length)]
		))
		.ToArray();
	return forecast;
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}