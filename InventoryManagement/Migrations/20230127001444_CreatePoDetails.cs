using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    public partial class CreatePoDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoHeader_Currencies_BaseCurrencyId",
                table: "PoHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PoHeader_Currencies_PoCurrencyId",
                table: "PoHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PoHeader_Suppliers_SupplierId",
                table: "PoHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoHeader",
                table: "PoHeader");

            migrationBuilder.RenameTable(
                name: "PoHeader",
                newName: "PoHeaders");

            migrationBuilder.RenameIndex(
                name: "IX_PoHeader_SupplierId",
                table: "PoHeaders",
                newName: "IX_PoHeaders_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_PoHeader_PoCurrencyId",
                table: "PoHeaders",
                newName: "IX_PoHeaders_PoCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_PoHeader_BaseCurrencyId",
                table: "PoHeaders",
                newName: "IX_PoHeaders_BaseCurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoHeaders",
                table: "PoHeaders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PoDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Quantity = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Fob = table.Column<decimal>(type: "smallmoney", nullable: false),
                    PrcInBaseCur = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoDetails_PoHeaders_PoId",
                        column: x => x.PoId,
                        principalTable: "PoHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoDetails_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoDetails_PoId",
                table: "PoDetails",
                column: "PoId");

            migrationBuilder.CreateIndex(
                name: "IX_PoDetails_ProductCode",
                table: "PoDetails",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_PoHeaders_Currencies_BaseCurrencyId",
                table: "PoHeaders",
                column: "BaseCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoHeaders_Currencies_PoCurrencyId",
                table: "PoHeaders",
                column: "PoCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoHeaders_Suppliers_SupplierId",
                table: "PoHeaders",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoHeaders_Currencies_BaseCurrencyId",
                table: "PoHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_PoHeaders_Currencies_PoCurrencyId",
                table: "PoHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_PoHeaders_Suppliers_SupplierId",
                table: "PoHeaders");

            migrationBuilder.DropTable(
                name: "PoDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoHeaders",
                table: "PoHeaders");

            migrationBuilder.RenameTable(
                name: "PoHeaders",
                newName: "PoHeader");

            migrationBuilder.RenameIndex(
                name: "IX_PoHeaders_SupplierId",
                table: "PoHeader",
                newName: "IX_PoHeader_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_PoHeaders_PoCurrencyId",
                table: "PoHeader",
                newName: "IX_PoHeader_PoCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_PoHeaders_BaseCurrencyId",
                table: "PoHeader",
                newName: "IX_PoHeader_BaseCurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoHeader",
                table: "PoHeader",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoHeader_Currencies_BaseCurrencyId",
                table: "PoHeader",
                column: "BaseCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoHeader_Currencies_PoCurrencyId",
                table: "PoHeader",
                column: "PoCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoHeader_Suppliers_SupplierId",
                table: "PoHeader",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
