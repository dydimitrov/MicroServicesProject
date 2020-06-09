using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWeb.Data.Migrations
{
    public partial class ChangedNameOfFacilitiesProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolDistnace",
                table: "Facilitieses");

            migrationBuilder.AddColumn<int>(
                name: "SchoolDistance",
                table: "Facilitieses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolDistance",
                table: "Facilitieses");

            migrationBuilder.AddColumn<int>(
                name: "SchoolDistnace",
                table: "Facilitieses",
                nullable: false,
                defaultValue: 0);
        }
    }
}
