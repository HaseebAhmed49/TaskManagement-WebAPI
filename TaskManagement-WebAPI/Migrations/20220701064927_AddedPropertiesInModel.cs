using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement_WebAPI.Migrations
{
    public partial class AddedPropertiesInModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "taskDescription",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "taskStatus",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "taskDescription",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "taskStatus",
                table: "Tasks");
        }
    }
}
