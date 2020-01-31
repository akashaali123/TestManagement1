using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestManagement1.Migrations
{
    public partial class AddtableCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCandidate",
                columns: table => new
                {
                    CandidateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 250, nullable: false),
                    LastName = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CurrentCompany = table.Column<string>(maxLength: 250, nullable: true),
                    TechStack = table.Column<string>(maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    VacancyId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCandidate", x => x.CandidateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCandidate");
        }
    }
}
