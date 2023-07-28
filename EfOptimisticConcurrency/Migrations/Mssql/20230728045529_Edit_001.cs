using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfOptimisticConcurrency.Migrations.Mssql
{
    public partial class Edit_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestOC3",
                columns: table => new
                {
                    idTestOC3 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOC3", x => x.idTestOC3);
                });

            migrationBuilder.InsertData(
                table: "TestOC3",
                columns: new[] { "idTestOC3", "Int", "Str" },
                values: new object[] { 1, 3, "str 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestOC3");
        }
    }
}
