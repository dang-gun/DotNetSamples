﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfOptimisticConcurrency.Migrations.Mssql
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestOC1",
                columns: table => new
                {
                    idTestOC1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOC1", x => x.idTestOC1);
                });

            migrationBuilder.CreateTable(
                name: "TestOC2",
                columns: table => new
                {
                    idTestOC2 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOC2", x => x.idTestOC2);
                });

            migrationBuilder.InsertData(
                table: "TestOC1",
                columns: new[] { "idTestOC1", "Int", "Str", "Version" },
                values: new object[] { 1, 1, "str 1", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "TestOC2",
                columns: new[] { "idTestOC2", "Int", "Str" },
                values: new object[] { 1, 2, "str 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestOC1");

            migrationBuilder.DropTable(
                name: "TestOC2");
        }
    }
}
