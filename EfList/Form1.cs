using EfList.Global;
using EfTest.Models;
using Microsoft.EntityFrameworkCore;
using ModelsDB;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EfList
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			//설정 파일 읽기
			string sJson = File.ReadAllText("SettingInfo_gitignore.json");
			SettingInfoModel? loadSetting = JsonConvert.DeserializeObject<SettingInfoModel>(sJson);

			//GlobalStatic.DbType = "sqlite";
			GlobalStatic.DbType = "mssql";

			switch (GlobalStatic.DbType)
			{
				case "sqlite":
					//Add-Migration InitialCreate -Context ModelsDB.DbModel_SqliteContext -OutputDir Migrations/Sqlite
					//Remove-Migration -Context ModelsDB.DbModel_SqliteContext
					GlobalStatic.DbConnectString
						= "Data Source=Test.db";

					using (DbModel_SqliteContext db1 = new DbModel_SqliteContext())
					{
						db1.Database.Migrate();
					}
					break;

				case "mssql":
					//Add-Migration InitialCreate -Context ModelsDB.DbModel_MssqlContext -OutputDir Migrations/Mssql
					//Update-Database -Context ModelsDB.DbModel_MssqlContext -Migration 0	
					//Remove-Migration -Context ModelsDB.DbModel_MssqlContext
					//ModelDllGlobal.DbConnectString = "Server=[주소];DataBase=[데이터 베이스];UId=[아이디];pwd=[비밀번호]";
					GlobalStatic.DbConnectString = loadSetting!.ConnectionString_Mssql;

					using (DbModel_MssqlContext db2 = new DbModel_MssqlContext())
					{
						db2.Database.Migrate();
					}
					break;
			}


		}

		private void button1_Click(object sender, EventArgs e)
		{
			List<EfList_Test2> efList_Test2s = new List<EfList_Test2>();

			using (DbModelContext db3 = new DbModelContext())
			{
				efList_Test2s
					= db3.EfList_Test2.ToList();
			}

			Debug.WriteLine(efList_Test2s.Count);
			Debug.WriteLine(efList_Test2s[0].ListString2);
		}
	}
}