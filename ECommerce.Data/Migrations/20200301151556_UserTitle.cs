using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Data.Migrations
{
    public partial class UserTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Active", "CreateDate", "Deleted", "Name", "UpdateDate" },
                values: new object[] { 1, true, new DateTime(2020, 3, 1, 15, 15, 56, 528, DateTimeKind.Utc), false, "Müşteri", null });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Active", "CreateDate", "Deleted", "Name", "UpdateDate" },
                values: new object[] { 2, true, new DateTime(2020, 3, 1, 15, 15, 56, 528, DateTimeKind.Utc), false, "Yönetici", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "TitleId" },
                values: new object[] { new DateTime(2020, 3, 1, 15, 15, 56, 529, DateTimeKind.Utc), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TitleId",
                table: "Users",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Titles_TitleId",
                table: "Users",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Titles_TitleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Users_TitleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 2, 29, 13, 59, 54, 399, DateTimeKind.Utc));
        }
    }
}
