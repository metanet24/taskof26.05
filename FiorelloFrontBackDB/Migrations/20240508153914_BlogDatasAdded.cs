using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFrontBackDB.Migrations
{
    public partial class BlogDatasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 8, 19, 39, 14, 612, DateTimeKind.Local).AddTicks(9498), "Description 1", "blog-feature-img-1.jpg", false, "Blog 1" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 2, new DateTime(2024, 5, 8, 19, 39, 14, 612, DateTimeKind.Local).AddTicks(9509), "Description 2", "blog-feature-img-3.jpg", false, "Blog 2" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 3, new DateTime(2024, 5, 8, 19, 39, 14, 612, DateTimeKind.Local).AddTicks(9509), "Description 3", "blog-feature-img-4.jpg", false, "Blog 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
