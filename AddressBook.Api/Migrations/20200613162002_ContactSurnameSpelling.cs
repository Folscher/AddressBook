using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.Api.Migrations
{
    public partial class ContactSurnameSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Contacts",
                newName: "Surname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Contacts",
                newName: "SurName");
        }
    }
}
