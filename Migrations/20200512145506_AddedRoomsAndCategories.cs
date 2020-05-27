using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrandPeltekHotel.Migrations
{
    public partial class AddedRoomsAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    NumberofBookedRooms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RoomCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Bedroom with a queen-sized bed, living room with a couch, table and fully equpped kitchen", "Apartments" },
                    { 2, "Bedroom with a queen-sized bed and couch", "Double-bed rooms" },
                    { 3, "Bedroom with two separate medium-sized beds for minimum intimacy", "Rooms with two separate beds" },
                    { 4, "Bedroom with three separate medium-sized beds", "Rooms with three separate beds" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CategoryId" },
                values: new object[,]
                {
                    { 18, 4 },
                    { 17, 4 },
                    { 16, 4 },
                    { 15, 3 },
                    { 14, 3 },
                    { 13, 3 },
                    { 12, 3 },
                    { 11, 3 },
                    { 10, 2 },
                    { 8, 2 },
                    { 19, 4 },
                    { 7, 2 },
                    { 6, 2 },
                    { 5, 1 },
                    { 4, 1 },
                    { 3, 1 },
                    { 2, 1 },
                    { 1, 1 },
                    { 9, 2 },
                    { 20, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RoomCategories");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Phone", "SignedIn" },
                values: new object[] { 1, "bpeltekov@abv.bg", "Purvan", "Purvanov", "parola", 882023840, false });
        }
    }
}
