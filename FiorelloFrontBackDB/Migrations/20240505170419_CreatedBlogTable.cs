using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFrontBackDB.Migrations
{
    public partial class CreatedBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "SliderInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Positions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Experts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "ExpertImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "AboutParts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 5, 21, 4, 19, 639, DateTimeKind.Local).AddTicks(1565), "Description 1", "blog-feature-img-1.jpg", false, "Blog 1" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 2, new DateTime(2024, 5, 5, 21, 4, 19, 639, DateTimeKind.Local).AddTicks(1581), "Description 2", "blog-feature-img-3.jpg", false, "Blog 2" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 3, new DateTime(2024, 5, 5, 21, 4, 19, 639, DateTimeKind.Local).AddTicks(1582), "Description 3", "blog-feature-img-4.jpg", false, "Blog 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "SliderInfos");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Experts");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "ExpertImages");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "AboutParts");
        }
    }
}
