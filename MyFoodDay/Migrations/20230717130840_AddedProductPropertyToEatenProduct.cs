using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFoodDay.Migrations
{
    public partial class AddedProductPropertyToEatenProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "EatenProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EatenProducts_ProductId",
                table: "EatenProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_EatenProducts_Products_ProductId",
                table: "EatenProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EatenProducts_Products_ProductId",
                table: "EatenProducts");

            migrationBuilder.DropIndex(
                name: "IX_EatenProducts_ProductId",
                table: "EatenProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "EatenProducts");
        }
    }
}
