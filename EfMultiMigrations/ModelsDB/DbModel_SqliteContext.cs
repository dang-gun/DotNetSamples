using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EfMultiMigrations;
using EfMultiMigrations.Models;
using System.Text;

namespace ModelsDB;

public class DbModel_SqliteContext : DbModelContext
{
	//protected override void OnConfiguring(DbContextOptionsBuilder options)
	//{
	//	options.UseSqlite(ModelDllGlobal.DbConnectString);
	//}
}
