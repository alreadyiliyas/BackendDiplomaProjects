using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaProjects.DataAccess.Migrations
{
    public partial class migr_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Applications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Applications",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
