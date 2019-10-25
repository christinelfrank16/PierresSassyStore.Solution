using Microsoft.EntityFrameworkCore.Migrations;

namespace PierresSassyStore.Migrations
{
    public partial class AddImgUrlProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image_url",
                table: "Treats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image_url",
                table: "Flavors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image_url",
                table: "Treats");

            migrationBuilder.DropColumn(
                name: "Image_url",
                table: "Flavors");
        }
    }
}
