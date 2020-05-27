using Microsoft.EntityFrameworkCore.Migrations;

namespace GrandPeltekHotel.Migrations
{
    public partial class AddedFirstUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    Password = table.Column<string>(maxLength: 25, nullable: false),
                    SignedIn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Phone", "SignedIn" },
                values: new object[] { 1, "bpeltekov@abv.bg", "Purvan", "Purvanov", "parola", 882023840, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
