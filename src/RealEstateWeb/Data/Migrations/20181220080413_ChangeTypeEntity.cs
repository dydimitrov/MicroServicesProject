using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWeb.Data.Migrations
{
    public partial class ChangeTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyPurpose",
                table: "Properties",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyPurpose",
                table: "Properties");
        }
    }
}
