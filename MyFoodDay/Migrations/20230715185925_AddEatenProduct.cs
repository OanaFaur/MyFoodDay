using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFoodDay.Migrations
{
    public partial class AddEatenProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EatenProducts",
                columns: table => new
                {
                    ConsumedProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityConsumed = table.Column<double>(type: "float", nullable: false),
                    CaloriesConsumed = table.Column<double>(type: "float", nullable: false),
                    ProteinsConsumed = table.Column<double>(type: "float", nullable: false),
                    FatsConsumed = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAdditionalInfoUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EatenProducts", x => x.ConsumedProductId);
                    table.ForeignKey(
                        name: "FK_EatenProducts_UserAdditionalInfo_UserAdditionalInfoUserId",
                        column: x => x.UserAdditionalInfoUserId,
                        principalTable: "UserAdditionalInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EatenProducts_UserAdditionalInfoUserId",
                table: "EatenProducts",
                column: "UserAdditionalInfoUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EatenProducts");
        }
    }
}
