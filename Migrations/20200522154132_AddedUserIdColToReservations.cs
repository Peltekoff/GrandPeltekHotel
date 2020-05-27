using Microsoft.EntityFrameworkCore.Migrations;

namespace GrandPeltekHotel.Migrations
{
    public partial class AddedUserIdColToReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "NumberofBookedRooms",
                table: "Reservations",
                newName: "NumberOfBookedRooms");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfBookedRooms",
                table: "Reservations",
                newName: "NumberofBookedRooms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");
        }
    }
}
