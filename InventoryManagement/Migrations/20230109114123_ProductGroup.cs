using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    public partial class ProductGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductProfiles_ProductProfileId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductProfileId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductProfileId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductProfileId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProfiles", x => x.Id);
                });

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
    }
}
