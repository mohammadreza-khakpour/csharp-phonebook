using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_Console.Migrations
{
    public partial class fifthM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberPhoneNumber",
                table: "Numbers",
                newName: "ContactValue");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Emails",
                newName: "ContactValue");

            migrationBuilder.AddColumn<string>(
                name: "ContactTitle",
                table: "Numbers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactTitle",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactTitle",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "ContactTitle",
                table: "Emails");

            migrationBuilder.RenameColumn(
                name: "ContactValue",
                table: "Numbers",
                newName: "NumberPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ContactValue",
                table: "Emails",
                newName: "EmailAddress");
        }
    }
}
