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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Sync up new feature meeting...", new DateTime(2023, 10, 26, 9, 54, 27, 246, DateTimeKind.Local).AddTicks(8059), "Florida", new DateTime(2023, 10, 25, 9, 54, 27, 246, DateTimeKind.Local).AddTicks(8026), "SyncUp Meeting" },
                    { 2, "Follow-up Dentist...", new DateTime(2023, 10, 27, 9, 54, 27, 246, DateTimeKind.Local).AddTicks(8090), "San Francisco", new DateTime(2023, 10, 25, 9, 54, 27, 246, DateTimeKind.Local).AddTicks(8089), "Dentist appointmentt" },
                    { 3, "Daily Meeting on green room...", new DateTime(2023, 10, 28, 9, 54, 27, 246, DateTimeKind.Local).AddTicks(8094), "Michigan", new DateTime(2023, 10, 25, 9, 54, 27, 246, DateTimeKind.Local).AddTicks(8093), "Daily Metting" },
                    { 4, "Meeting with friends...", new DateTime(2023, 10, 29, 9, 54, 27, 246, DateTimeKind.Local).AddTicks(8097), "San Francisco", new DateTime(2023, 10, 25, 9, 54, 27, 246, DateTimeKind.Local).AddTicks(8096), "Friends Meeting" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
