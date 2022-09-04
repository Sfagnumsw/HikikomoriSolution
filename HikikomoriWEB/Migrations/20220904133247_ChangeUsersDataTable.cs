using Microsoft.EntityFrameworkCore.Migrations;

namespace HikikomoriWEB.Migrations
{
    public partial class ChangeUsersDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRole",
                table: "UsersData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRole",
                table: "UsersData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
