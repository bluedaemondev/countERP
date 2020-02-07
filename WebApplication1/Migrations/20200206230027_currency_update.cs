using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class currency_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "sale_order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaxId",
                table: "account_invoice",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_sale_order_CurrencyId",
                table: "sale_order",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_account_invoice_TaxId",
                table: "account_invoice",
                column: "TaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_account_invoice_tax_TaxId",
                table: "account_invoice",
                column: "TaxId",
                principalTable: "tax",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_order_res_currency_CurrencyId",
                table: "sale_order",
                column: "CurrencyId",
                principalTable: "res_currency",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_invoice_tax_TaxId",
                table: "account_invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_order_res_currency_CurrencyId",
                table: "sale_order");

            migrationBuilder.DropIndex(
                name: "IX_sale_order_CurrencyId",
                table: "sale_order");

            migrationBuilder.DropIndex(
                name: "IX_account_invoice_TaxId",
                table: "account_invoice");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "sale_order");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "account_invoice");
        }
    }
}
