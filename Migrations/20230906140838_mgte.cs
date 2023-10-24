using Microsoft.EntityFrameworkCore.Migrations;

namespace StayHappy.Migrations
{
    public partial class mgte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "RoomDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "RoomDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
