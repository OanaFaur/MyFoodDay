using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFoodDay.Migrations
{
    public partial class UpdatedEatenProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EatenProducts_UserAdditionalInfo_UserAdditionalInfoUserId",
                table: "EatenProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdditionalInfo_AspNetUsers_Email",
                table: "UserAdditionalInfo");

            migrationBuilder.DropTable(
                name: "ConsumedProducts");

            migrationBuilder.DropIndex(
                name: "IX_EatenProducts_UserAdditionalInfoUserId",
                table: "EatenProducts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "EatenProducts");

            migrationBuilder.DropColumn(
                name: "UserAdditionalInfoUserId",
                table: "EatenProducts");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UserAdditionalInfo",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserAdditionalInfo_Email",
                table: "UserAdditionalInfo",
                newName: "IX_UserAdditionalInfo_UserId1");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EatenProducts",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdditionalInfo_AspNetUsers_UserId1",
                table: "UserAdditionalInfo",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EatenProducts_AspNetUsers_UserId",
                table: "EatenProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdditionalInfo_AspNetUsers_UserId1",
                table: "UserAdditionalInfo");

            migrationBuilder.DropIndex(
                name: "IX_EatenProducts_UserId",
                table: "EatenProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EatenProducts");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "UserAdditionalInfo",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_UserAdditionalInfo_UserId1",
                table: "UserAdditionalInfo",
                newName: "IX_UserAdditionalInfo_Email");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EatenProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAdditionalInfoUserId",
                table: "EatenProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConsumedProducts",
                columns: table => new
                {
                    ConsumedProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaloriesConsumed = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatsConsumed = table.Column<double>(type: "float", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProteinsConsumed = table.Column<double>(type: "float", nullable: false),
                    QuantityConsumed = table.Column<double>(type: "float", nullable: false),
                    UserAdditionalInfoUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumedProducts", x => x.ConsumedProductId);
                    table.ForeignKey(
                        name: "FK_ConsumedProducts_UserAdditionalInfo_UserAdditionalInfoUserId",
                        column: x => x.UserAdditionalInfoUserId,
                        principalTable: "UserAdditionalInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EatenProducts_UserAdditionalInfoUserId",
                table: "EatenProducts",
                column: "UserAdditionalInfoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedProducts_UserAdditionalInfoUserId",
                table: "ConsumedProducts",
                column: "UserAdditionalInfoUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EatenProducts_UserAdditionalInfo_UserAdditionalInfoUserId",
                table: "EatenProducts",
                column: "UserAdditionalInfoUserId",
                principalTable: "UserAdditionalInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdditionalInfo_AspNetUsers_Email",
                table: "UserAdditionalInfo",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
