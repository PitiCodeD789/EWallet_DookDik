using Microsoft.EntityFrameworkCore.Migrations;

namespace EWallet.DataAcess.Migrations
{
    public partial class test_indexkey_and_alternatekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Otp",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Otp_Email",
                table: "Otp",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Otp_Email",
                table: "Otp");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Otp",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
