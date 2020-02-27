using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestManagement1.Migrations
{
    public partial class addcolumnUpdatedByandDateinTblCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TblCompany",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TblCompany",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TblCompany",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TblCompany",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TblCompany",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TblCompany");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblCompany");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TblCompany");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TblCompany");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TblCompany");
        }
    }
}
