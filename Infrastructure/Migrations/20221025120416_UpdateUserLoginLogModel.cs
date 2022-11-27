using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateUserLoginLogModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginLogs_Userss_UserId",
                table: "UserLoginLogs");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginLogs_UserId",
                table: "UserLoginLogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserLoginLogs");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserLoginLogs",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HashPassword",
                table: "UserLoginLogs",
                type: "varchar(255)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserLoginLogs");

            migrationBuilder.DropColumn(
                name: "HashPassword",
                table: "UserLoginLogs");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserLoginLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLogs_UserId",
                table: "UserLoginLogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginLogs_Userss_UserId",
                table: "UserLoginLogs",
                column: "UserId",
                principalTable: "Userss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
