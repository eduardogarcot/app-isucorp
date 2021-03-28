using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations
{
    public partial class CreateGetAllContactsStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder storedProcedure = new StringBuilder();
            storedProcedure.Append("CREATE PROCEDURE dbo.GetAllContacts" + Environment.NewLine);
            storedProcedure.Append("AS" + Environment.NewLine);
            storedProcedure.Append("BEGIN" + Environment.NewLine);
            storedProcedure.Append(@"SELECT * FROM Contacts" + Environment.NewLine);
            storedProcedure.Append("END" + Environment.NewLine);
            migrationBuilder.Sql(storedProcedure.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetAllContacts");
        }
    }
}
