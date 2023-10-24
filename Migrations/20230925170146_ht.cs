using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayHappy.Migrations
{
    public partial class ht : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BankCard");

            migrationBuilder.AlterColumn<string>(
                name: "ExpiryDate",
                table: "BankCard",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CVV",
                table: "BankCard",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "BankCard");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "BankCard",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BankCard",
                type: "int",
                nullable: true);
        }
    }
}
