using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFoodDay.Migrations
{
    public partial class UpdatedUserAdditionalInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAdditionalInfo_AspNetUsers_UserId",
                table: "UserAdditionalInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserAdditionalInfo_UserId",
                table: "UserAdditionalInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAdditionalInfo");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserAdditionalInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UserAdditionalInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserAdditionalInfo");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "UserAdditionalInfo");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserAdditionalInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAdditionalInfo_UserId",
                table: "UserAdditionalInfo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdditionalInfo_AspNetUsers_UserId",
                table: "UserAdditionalInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
