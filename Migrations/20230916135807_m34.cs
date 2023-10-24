using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayHappy.Migrations
{
    public partial class m34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Feedbacks",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Feedbacks",
                newName: "UserId");
        }
    }
}
