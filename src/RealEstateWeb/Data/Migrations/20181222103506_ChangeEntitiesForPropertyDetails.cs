using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWeb.Data.Migrations
{
    public partial class ChangeEntitiesForPropertyDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalArea",
                table: "PropertyDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                table: "Properties",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalArea",
                table: "PropertyDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Properties",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
