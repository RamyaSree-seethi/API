using Microsoft.EntityFrameworkCore.Migrations;

namespace StayHappy.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RoomDetails_RoomDetailId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomDetailId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomDetailId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RoomDetails_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "RoomDetails",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RoomDetails_RoomId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "RoomDetailId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomDetailId",
                table: "Bookings",
                column: "RoomDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RoomDetails_RoomDetailId",
                table: "Bookings",
                column: "RoomDetailId",
                principalTable: "RoomDetails",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
