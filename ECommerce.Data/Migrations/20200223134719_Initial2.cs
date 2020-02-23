using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Admin", "CreateDate", "Deleted", "Email", "Name", "Password", "Surname", "UpdateDate" },
                values: new object[] { 1, true, true, new DateTime(2020, 2, 23, 13, 47, 19, 12, DateTimeKind.Utc), false, "admin@admin.com", "Admin", "7C222FB2927D828AF22F592134E8932480637C0D", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Users");
        }
    }
}
