using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class prices_taxes_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Create_uid",
                table: "product_product");

            migrationBuilder.DropColumn(
                name: "Write_date",
                table: "product_product");

            migrationBuilder.DropColumn(
                name: "Write_uid",
                table: "product_product");

            migrationBuilder.AddColumn<decimal>(
                name: "list_price",
                table: "product_template",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "qty_available",
                table: "product_template",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "qty_virtual",
                table: "product_template",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "tax_idId",
                table: "product_template",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "taxedPrice",
                table: "product_template",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "list_price",
                table: "product_product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "qty_available",
                table: "product_product",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "qty_virtual",
                table: "product_product",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "tax_idId",
                table: "product_product",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "taxedPrice",
                table: "product_product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_product_template_tax_idId",
                table: "product_template",
                column: "tax_idId");

            migrationBuilder.CreateIndex(
                name: "IX_product_product_tax_idId",
                table: "product_product",
                column: "tax_idId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_tax_tax_idId",
                table: "product_product",
                column: "tax_idId",
                principalTable: "tax",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_template_tax_tax_idId",
                table: "product_template",
                column: "tax_idId",
                principalTable: "tax",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_product_tax_tax_idId",
                table: "product_product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_template_tax_tax_idId",
                table: "product_template");

            migrationBuilder.DropIndex(
                name: "IX_product_template_tax_idId",
                table: "product_template");

            migrationBuilder.DropIndex(
                name: "IX_product_product_tax_idId",
                table: "product_product");

            migrationBuilder.DropColumn(
                name: "list_price",
                table: "product_template");

            migrationBuilder.DropColumn(
                name: "qty_available",
                table: "product_template");

            migrationBuilder.DropColumn(
                name: "qty_virtual",
                table: "product_template");

            migrationBuilder.DropColumn(
                name: "tax_idId",
                table: "product_template");

            migrationBuilder.DropColumn(
                name: "taxedPrice",
                table: "product_template");

            migrationBuilder.DropColumn(
                name: "list_price",
                table: "product_product");

            migrationBuilder.DropColumn(
                name: "qty_available",
                table: "product_product");

            migrationBuilder.DropColumn(
                name: "qty_virtual",
                table: "product_product");

            migrationBuilder.DropColumn(
                name: "tax_idId",
                table: "product_product");

            migrationBuilder.DropColumn(
                name: "taxedPrice",
                table: "product_product");

            migrationBuilder.AddColumn<int>(
                name: "Create_uid",
                table: "product_product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Write_date",
                table: "product_product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Write_uid",
                table: "product_product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
