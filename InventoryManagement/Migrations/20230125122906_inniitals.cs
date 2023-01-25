using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    public partial class inniitals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductProfileId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductProfileId",
                table: "Products",
                column: "ProductProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductProfiles_ProductProfileId",
                table: "Products",
                column: "ProductProfileId",
                principalTable: "ProductProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductProfiles_ProductProfileId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductProfileId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductProfileId",
                table: "Products");
        }
    }
}
