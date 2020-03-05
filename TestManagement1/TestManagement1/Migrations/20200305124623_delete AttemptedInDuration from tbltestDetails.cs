using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestManagement1.Migrations
{
    public partial class deleteAttemptedInDurationfromtbltestDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttemptedInDuration",
                table: "TblTestDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AttemptedInDuration",
                table: "TblTestDetails",
                type: "datetime2",
                nullable: true);
        }
    }
}
