using Microsoft.EntityFrameworkCore.Migrations;

namespace KienLongC.Migrations
{
    public partial class Captcha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaptchaCode",
                table: "Form",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaptchaCode",
                table: "Form");
        }
    }
}
