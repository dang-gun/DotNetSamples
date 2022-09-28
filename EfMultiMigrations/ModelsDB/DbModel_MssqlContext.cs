using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EfMultiMigrations;
using EfMultiMigrations.Models;

namespace ModelsDB;

public class DbModel_MssqlContext : DbModelContext
{
	//protected override void OnConfiguring(DbContextOptionsBuilder options)
	//{
	//	options.UseSqlServer(ModelDllGlobal.DbConnectString);
	//}
}
