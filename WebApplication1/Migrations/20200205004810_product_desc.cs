using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class product_desc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "product_template",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "product_product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "product_template");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "product_product");
        }
    }
}
