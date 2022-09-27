using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EfMultiMigrations;
using EfMultiMigrations.Models;
using System.Text;

namespace ModelsDB;

public class DbModel_SqliteContext : DbModelContext
{


	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		//string currentDirectory = Directory.GetCurrentDirectory();
		//string aa = Path.Combine(currentDirectory, "DbInfo.json");
		////파일 읽기
		//string sJson = File.ReadAllText(aa, Encoding.Default);


		//ModelDllGlobal.DbType = DbType.Sqlite;
		//ModelDllGlobal.DbConnectString = "Data Source=Test.db";

		options.UseSqlite(ModelDllGlobal.DbConnectString);
	}

}
