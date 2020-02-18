using Microsoft.EntityFrameworkCore.Migrations;

namespace TestManagement1.Migrations
{
    public partial class RenameTestDetailIdtoCandidateIdintblTestDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestDetailId",
                table: "TblTestDetails");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "TblTestDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "TblTestDetails");

            migrationBuilder.AddColumn<int>(
                name: "TestDetailId",
                table: "TblTestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
