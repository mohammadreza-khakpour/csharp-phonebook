using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_Console.Migrations
{
    public partial class secondM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhonebookTitle",
                table: "PhoneBooks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "PersonIsFemale",
                table: "Persons",
                newName: "IsFemale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PhoneBooks",
                newName: "PhonebookTitle");

            migrationBuilder.RenameColumn(
                name: "IsFemale",
                table: "Persons",
                newName: "PersonIsFemale");
        }
    }
}
