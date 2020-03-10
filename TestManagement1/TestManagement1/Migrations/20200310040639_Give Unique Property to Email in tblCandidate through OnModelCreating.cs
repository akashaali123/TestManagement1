using Microsoft.EntityFrameworkCore.Migrations;

namespace TestManagement1.Migrations
{
    public partial class GiveUniquePropertytoEmailintblCandidatethroughOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TblCandidate_Email",
                table: "TblCandidate",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TblCandidate_Email",
                table: "TblCandidate");
        }
    }
}
