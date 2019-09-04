using Microsoft.EntityFrameworkCore.Migrations;

namespace EWallet.DataAcess.Migrations
{
    public partial class add_alternatekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_Email",
                table: "User",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_Email",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");
        }
    }
}
