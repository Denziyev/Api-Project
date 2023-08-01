using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class updated2producttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreadetAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 28, 3, 47, DateTimeKind.Utc).AddTicks(1579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 30, 18, 41, 20, 900, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreadetAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 28, 3, 47, DateTimeKind.Utc).AddTicks(434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 30, 18, 41, 20, 900, DateTimeKind.Utc).AddTicks(6231));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreadetAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 30, 18, 41, 20, 900, DateTimeKind.Utc).AddTicks(7715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 28, 3, 47, DateTimeKind.Utc).AddTicks(1579));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreadetAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 30, 18, 41, 20, 900, DateTimeKind.Utc).AddTicks(6231),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 28, 3, 47, DateTimeKind.Utc).AddTicks(434));
        }
    }
}
