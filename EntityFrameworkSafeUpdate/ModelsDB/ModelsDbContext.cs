using System;
using EntityFrameworkSafeUpdate.Global;
using Microsoft.EntityFrameworkCore;

namespace ModelsDB
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelsDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            

            switch (GlobalStatic.DBType)
            {
                case "sqlite":
                    options.UseSqlite(GlobalStatic.DBString);
                    break;
                case "mysql":
                    //options.UseSqlite(GlobalStatic.DBString);
                    break;

                case "mssql":
                default:
                    options.UseSqlServer(GlobalStatic.DBString);
                    break;
            }
        }

        /// <summary>
        /// 서버 세팅 정보
        /// </summary>
        public DbSet<SiteData> SiteData { get; set; }
        /// <summary>
        /// 사이트 전체 정보 - 오늘 방문자.
        /// </summary>
        public DbSet<SiteData_VisitToday> SiteData_VisitToday { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SiteData>().Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<SiteData>().HasData(
                new SiteData
                {
                    idSiteData = 1,
                    VisitTotal = 0,
                    VisitTotalCount = 0,
                });

        }
    }
}
