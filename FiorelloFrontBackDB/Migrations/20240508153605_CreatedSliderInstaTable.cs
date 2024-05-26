using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFrontBackDB.Migrations
{
    public partial class CreatedSliderInstaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "InstaSliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstaSliders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstaSliders");

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 8, 18, 59, 4, 118, DateTimeKind.Local).AddTicks(4560), "Description 1", "blog-feature-img-1.jpg", false, "Blog 1" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 2, new DateTime(2024, 5, 8, 18, 59, 4, 118, DateTimeKind.Local).AddTicks(4582), "Description 2", "blog-feature-img-3.jpg", false, "Blog 2" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 3, new DateTime(2024, 5, 8, 18, 59, 4, 118, DateTimeKind.Local).AddTicks(4583), "Description 3", "blog-feature-img-4.jpg", false, "Blog 3" });
        }
    }
}
