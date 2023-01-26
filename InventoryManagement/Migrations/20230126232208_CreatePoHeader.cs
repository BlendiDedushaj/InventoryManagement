using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    public partial class CreatePoHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PoDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    BaseCurrencyId = table.Column<int>(type: "int", nullable: false),
                    PoCurrencyId = table.Column<int>(type: "int", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "smallmoney", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "smallmoney", nullable: false),
                    QuotationNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    QuotationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentTerms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoHeader_Currencies_BaseCurrencyId",
                        column: x => x.BaseCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PoHeader_Currencies_PoCurrencyId",
                        column: x => x.PoCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PoHeader_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoHeader_BaseCurrencyId",
                table: "PoHeader",
                column: "BaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PoHeader_PoCurrencyId",
                table: "PoHeader",
                column: "PoCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PoHeader_SupplierId",
                table: "PoHeader",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoHeader");
        }
    }
}
