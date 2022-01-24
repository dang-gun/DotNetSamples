using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkSafeUpdate.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteData",
                columns: table => new
                {
                    idSiteData = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VisitTotal = table.Column<ulong>(type: "INTEGER", nullable: false),
                    VisitTotalCount = table.Column<ulong>(type: "INTEGER", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteData", x => x.idSiteData);
                });

            migrationBuilder.CreateTable(
                name: "SiteData_VisitToday",
                columns: table => new
                {
                    idSiteData_VisitToday = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Count = table.Column<ulong>(type: "INTEGER", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteData_VisitToday", x => x.idSiteData_VisitToday);
                });

            migrationBuilder.InsertData(
                table: "SiteData",
                columns: new[] { "idSiteData", "VisitTotal", "VisitTotalCount" },
                values: new object[] { 1L, 0ul, 0ul });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteData");

            migrationBuilder.DropTable(
                name: "SiteData_VisitToday");
        }
    }
}
