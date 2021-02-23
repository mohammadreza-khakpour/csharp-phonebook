using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_Console.Migrations
{
    public partial class thirdM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Number_Persons_PersonId",
                table: "Number");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Number",
                table: "Number");

            migrationBuilder.DropColumn(
                name: "PersonPhoneNumber",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Number",
                newName: "Numbers");

            migrationBuilder.RenameIndex(
                name: "IX_Number_PersonId",
                table: "Numbers",
                newName: "IX_Numbers_PersonId");

            migrationBuilder.AddColumn<string>(
                name: "PhonebookTitle",
                table: "PhoneBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Numbers",
                table: "Numbers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_Persons_PersonId",
                table: "Numbers",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Persons_PersonId",
                table: "Numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Numbers",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "PhonebookTitle",
                table: "PhoneBooks");

            migrationBuilder.RenameTable(
                name: "Numbers",
                newName: "Number");

            migrationBuilder.RenameIndex(
                name: "IX_Numbers_PersonId",
                table: "Number",
                newName: "IX_Number_PersonId");

            migrationBuilder.AddColumn<string>(
                name: "PersonPhoneNumber",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Number",
                table: "Number",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Number_Persons_PersonId",
                table: "Number",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
