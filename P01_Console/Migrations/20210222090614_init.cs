using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_Console.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonFatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonWebsiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonIsFemale = table.Column<bool>(type: "bit", nullable: false),
                    PersonPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonPhonebookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_PhoneBooks_PersonPhonebookId",
                        column: x => x.PersonPhonebookId,
                        principalTable: "PhoneBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonPhonebookId",
                table: "Persons",
                column: "PersonPhonebookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PhoneBooks");
        }
    }
}
