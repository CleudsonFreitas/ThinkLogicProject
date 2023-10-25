using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[] { 1, "Event One", new DateTime(2023, 10, 25, 18, 48, 59, 981, DateTimeKind.Local).AddTicks(459), "United States", new DateTime(2023, 10, 24, 18, 48, 59, 981, DateTimeKind.Local).AddTicks(420), "First event" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[] { 2, "Event Two", new DateTime(2023, 10, 26, 18, 48, 59, 981, DateTimeKind.Local).AddTicks(527), "United States", new DateTime(2023, 10, 24, 18, 48, 59, 981, DateTimeKind.Local).AddTicks(508), "Second event" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[] { 3, "Event Three", new DateTime(2023, 10, 27, 18, 48, 59, 981, DateTimeKind.Local).AddTicks(562), "United States", new DateTime(2023, 10, 24, 18, 48, 59, 981, DateTimeKind.Local).AddTicks(547), "Third event" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[] { 4, "Event Four", new DateTime(2023, 10, 28, 18, 48, 59, 981, DateTimeKind.Local).AddTicks(601), "United States", new DateTime(2023, 10, 24, 18, 48, 59, 981, DateTimeKind.Local).AddTicks(586), "Forth event" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
