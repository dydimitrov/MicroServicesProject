using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWeb.Data.Migrations
{
    public partial class AddedFacilitiesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberOfBedrooms",
                table: "PropertyDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBeds",
                table: "PropertyDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacilitiesId",
                table: "Properties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Facilitieses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodStores = table.Column<double>(nullable: false),
                    FoodStoreDistance = table.Column<int>(nullable: false),
                    Hospitals = table.Column<double>(nullable: false),
                    HospitalDistance = table.Column<int>(nullable: false),
                    School = table.Column<double>(nullable: false),
                    SchoolDistnace = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilitieses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_FacilitiesId",
                table: "Properties",
                column: "FacilitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Facilitieses_FacilitiesId",
                table: "Properties",
                column: "FacilitiesId",
                principalTable: "Facilitieses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Facilitieses_FacilitiesId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Facilitieses");

            migrationBuilder.DropIndex(
                name: "IX_Properties_FacilitiesId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NumberOfBeds",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "FacilitiesId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfBedrooms",
                table: "PropertyDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
