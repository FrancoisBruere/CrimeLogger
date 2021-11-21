using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class CreateInitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrimeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Province_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    City_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Suburb_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    CrimeType_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CrimeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsTrueCrime = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMarkerAdded = table.Column<bool>(type: "INTEGER", nullable: false),
                    MyLat = table.Column<double>(type: "REAL", nullable: false),
                    MyLng = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrimeProvinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeProvinces", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "CrimeTypes",
                columns: table => new
                {
                    CrimeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeTypes", x => x.CrimeId);
                });

            migrationBuilder.CreateTable(
                name: "CrimeCities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProvinceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeCities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CrimeCities_CrimeProvinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "CrimeProvinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrimeSuburbs",
                columns: table => new
                {
                    SuburbId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeSuburbs", x => x.SuburbId);
                    table.ForeignKey(
                        name: "FK_CrimeSuburbs_CrimeCities_CityId",
                        column: x => x.CityId,
                        principalTable: "CrimeCities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeCities_ProvinceId",
                table: "CrimeCities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeSuburbs_CityId",
                table: "CrimeSuburbs",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeDetails");

            migrationBuilder.DropTable(
                name: "CrimeSuburbs");

            migrationBuilder.DropTable(
                name: "CrimeTypes");

            migrationBuilder.DropTable(
                name: "CrimeCities");

            migrationBuilder.DropTable(
                name: "CrimeProvinces");
        }
    }
}
