using Microsoft.EntityFrameworkCore.Migrations;

namespace TestManagement1.Migrations
{
    public partial class AddUser_NameinTblUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "AspNetUsers",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
