using Microsoft.EntityFrameworkCore.Migrations;

namespace TestManagement1.Migrations
{
    public partial class addcolumntimefromtblquestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "TblQuestion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "TblQuestion");
        }
    }
}
