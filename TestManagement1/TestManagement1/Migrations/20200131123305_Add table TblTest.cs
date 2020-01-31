using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestManagement1.Migrations
{
    public partial class AddtableTblTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblTest",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    ExpLevelId = table.Column<int>(nullable: true),
                    TestDate = table.Column<DateTime>(nullable: true),
                    TestStatus = table.Column<string>(maxLength: 500, nullable: true),
                    TotalQuestion = table.Column<int>(nullable: true),
                    AttemptedQuestion = table.Column<int>(nullable: true),
                    Percentage = table.Column<float>(nullable: true),
                    CorrectAnswer = table.Column<int>(nullable: true),
                    WrongAnswer = table.Column<int>(nullable: true),
                    QuestionSkipped = table.Column<int>(nullable: true),
                    Duration = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTest", x => x.TestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblTest");
        }
    }
}
