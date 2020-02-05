using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class currency_cr_rate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "res_currency",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    active = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    code = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    create_uid = table.Column<int>(nullable: false),
                    write_uid = table.Column<int>(nullable: false),
                    write_date = table.Column<DateTime>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_currency", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "res_currency_rate",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(unicode: false, nullable: false, defaultValueSql: "(getdate())"),
                    ratio = table.Column<decimal>(unicode: false, nullable: false),
                    active = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    create_uid = table.Column<int>(nullable: false),
                    write_uid = table.Column<int>(nullable: false),
                    write_date = table.Column<DateTime>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_currency_rate", x => x.id);
                    table.ForeignKey(
                        name: "FK__res_currency_i__currency_rate__60A75C0F",
                        column: x => x.Currency_id,
                        principalTable: "res_currency",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_product_product_currencyId",
                table: "product_product",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_product_template_product_category_id",
                table: "product_template",
                column: "product_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_template_uom_id",
                table: "product_template",
                column: "uom_id");

            migrationBuilder.CreateIndex(
                name: "IX_res_currency_name",
                table: "res_currency",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_res_currency_rate_Currency_id",
                table: "res_currency_rate",
                column: "Currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_res_currency_rate_name",
                table: "res_currency_rate",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_res_group_res_group_parent_id",
                table: "res_group",
                column: "res_group_parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_res_group_rule_rel_res_group_id",
                table: "res_group_rule_rel",
                column: "res_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_res_group_rule_rel_res_rule_id",
                table: "res_group_rule_rel",
                column: "res_rule_id");

            migrationBuilder.CreateIndex(
                name: "IX_res_user_employee_id",
                table: "res_user",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_order_payment_id",
                table: "sale_order",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_sale_order_line_tax_id",
                table: "sale_order_line",
                column: "tax_id");

            migrationBuilder.CreateIndex(
                name: "IX_so_line_inv_line_rel_inv_line_id",
                table: "so_line_inv_line_rel",
                column: "inv_line_id");

            migrationBuilder.CreateIndex(
                name: "IX_so_line_inv_line_rel_so_line_id",
                table: "so_line_inv_line_rel",
                column: "so_line_id");

            migrationBuilder.CreateIndex(
                name: "IX_so_line_invoice_rel_inv_id",
                table: "so_line_invoice_rel",
                column: "inv_id");

            migrationBuilder.CreateIndex(
                name: "IX_so_line_invoice_rel_so_id",
                table: "so_line_invoice_rel",
                column: "so_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hr_contract_employee_rel");

            migrationBuilder.DropTable(
                name: "product_product");

            migrationBuilder.DropTable(
                name: "res_company");

            migrationBuilder.DropTable(
                name: "res_currency_rate");

            migrationBuilder.DropTable(
                name: "res_group_rule_rel");

            migrationBuilder.DropTable(
                name: "res_user");

            migrationBuilder.DropTable(
                name: "so_line_inv_line_rel");

            migrationBuilder.DropTable(
                name: "so_line_invoice_rel");

            migrationBuilder.DropTable(
                name: "product_template");

            migrationBuilder.DropTable(
                name: "res_currency");

            migrationBuilder.DropTable(
                name: "res_group");

            migrationBuilder.DropTable(
                name: "res_group_rule");

            migrationBuilder.DropTable(
                name: "hr_employee");

            migrationBuilder.DropTable(
                name: "account_invoice_line");

            migrationBuilder.DropTable(
                name: "sale_order_line");

            migrationBuilder.DropTable(
                name: "product_category");

            migrationBuilder.DropTable(
                name: "uom");

            migrationBuilder.DropTable(
                name: "hr_contract");

            migrationBuilder.DropTable(
                name: "res_partner");

            migrationBuilder.DropTable(
                name: "account_invoice");

            migrationBuilder.DropTable(
                name: "tax");

            migrationBuilder.DropTable(
                name: "sale_order");

            migrationBuilder.DropTable(
                name: "payment");
        }
    }
}
