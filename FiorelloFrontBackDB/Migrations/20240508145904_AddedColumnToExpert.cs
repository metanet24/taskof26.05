using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFrontBackDB.Migrations
{
    public partial class AddedColumnToExpert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpertOpinion",
                table: "Experts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 8, 18, 59, 4, 118, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 8, 18, 59, 4, 118, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 8, 18, 59, 4, 118, DateTimeKind.Local).AddTicks(4583));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpertOpinion",
                table: "Experts");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 5, 21, 4, 19, 639, DateTimeKind.Local).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 5, 21, 4, 19, 639, DateTimeKind.Local).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 5, 21, 4, 19, 639, DateTimeKind.Local).AddTicks(1582));
        }
    }
}
