using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Migrations
{
    public partial class fourths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desciption",
                table: "Tasks",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tasks",
                newName: "Desciption");
        }
    }
}
