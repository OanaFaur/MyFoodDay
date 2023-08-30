using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFoodDay.Migrations
{
    public partial class AddUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAdditionalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DailyCalorieGoal = table.Column<double>(type: "float", nullable: false),
                    DailyProteinGoal = table.Column<double>(type: "float", nullable: false),
                    DailyFatGoal = table.Column<double>(type: "float", nullable: false),
                    WeightGoal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdditionalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdditionalInfo_AspNetUsers_Email",
                        column: x => x.Email,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAdditionalInfo_Email",
                table: "UserAdditionalInfo",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAdditionalInfo");
        }
    }
}
