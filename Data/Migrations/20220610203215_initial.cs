using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Noliktava.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PardPrece",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecKods = table.Column<int>(nullable: false),
                    Datums = table.Column<DateTime>(nullable: false),
                    Skaits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PardPrece", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prece",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecKods = table.Column<int>(nullable: false),
                    Nosaukums = table.Column<string>(nullable: true),
                    PiegKods = table.Column<int>(nullable: false),
                    Daudzums = table.Column<int>(nullable: false),
                    Cena = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prece", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PardPrece");

            migrationBuilder.DropTable(
                name: "Prece");
        }
    }
}
