using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_Console.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    PersonIsFemale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhonebookTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhonebookPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneBooks_Persons_PhonebookPersonId",
                        column: x => x.PhonebookPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Numbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhonebookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Numbers_PhoneBooks_PhonebookId",
                        column: x => x.PhonebookId,
                        principalTable: "PhoneBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_PhonebookId",
                table: "Numbers",
                column: "PhonebookId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBooks_PhonebookPersonId",
                table: "PhoneBooks",
                column: "PhonebookPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Numbers");

            migrationBuilder.DropTable(
                name: "PhoneBooks");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
