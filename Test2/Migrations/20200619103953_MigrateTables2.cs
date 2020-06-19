using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2.Migrations
{
    public partial class MigrateTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSupervisor",
                table: "Volunteer",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSupervisor",
                table: "Volunteer");
        }
    }
}
