using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWeb.Data.Migrations
{
    public partial class ChangePictureProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Pictures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Pictures");
        }
    }
}
