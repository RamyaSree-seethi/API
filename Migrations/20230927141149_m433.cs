using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayHappy.Migrations
{
    public partial class m433 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Refund",
                table: "Refund");

            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "Refund");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Refund");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Refund");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Refund");

            migrationBuilder.RenameTable(
                name: "Refund",
                newName: "Refunds");

            migrationBuilder.RenameColumn(
                name: "RequestedDate",
                table: "Refunds",
                newName: "RequestDate");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Refunds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "Refunds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessedDate",
                table: "Refunds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Refunds",
                table: "Refunds",
                column: "RefundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Refunds",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "ProcessedDate",
                table: "Refunds");

            migrationBuilder.RenameTable(
                name: "Refunds",
                newName: "Refund");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "Refund",
                newName: "RequestedDate");

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "Refund",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Refund",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Refund",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Refund",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Refund",
                table: "Refund",
                column: "RefundId");
        }
    }
}
