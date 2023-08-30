using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFoodDay.Migrations
{
    public partial class UpdatedEatenProductUserProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EatenProducts_AspNetUsers_UserId",
                table: "EatenProducts");

            migrationBuilder.DropIndex(
                name: "IX_EatenProducts_UserId",
                table: "EatenProducts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EatenProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EatenProducts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EatenProducts_UserId",
                table: "EatenProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EatenProducts_AspNetUsers_UserId",
                table: "EatenProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
