using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class ContactChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "contactType",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contactType",
                table: "Contacts");
        }
    }
}
