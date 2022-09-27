using EfMultiMigrations;
using EfMultiMigrations.Models;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ModelDllGlobal.DbType = TargetDbType.Sqlite;
//ModelDllGlobal.DbType = TargetDbType.Mssql;

switch (ModelDllGlobal.DbType)
{
	case TargetDbType.Mssql:
		//Add-Migration InitialCreate -Context ModelsDB.DbModel_MssqlContext -OutputDir Migrations/Mssql
		//Update-Database -Context ModelsDB.DbModel_MssqlContext -Migration 0	
		ModelDllGlobal.DbConnectString
			= "Server=[주소];DataBase=[데이터 베이스];UId=[아이디];pwd=[비밀번호]";
		break;

	case TargetDbType.Sqlite:
		//Add-Migration InitialCreate -Context ModelsDB.DbModel_SqliteContext -OutputDir Migrations/Sqlite
		ModelDllGlobal.DbConnectString
			= "Data Source=Test.db";
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