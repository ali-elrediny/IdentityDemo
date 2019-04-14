using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Identity.Migrations
{
    public partial class AddUserTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserTypeName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTypeName",
                table: "AspNetUsers");
        }
    }
}
