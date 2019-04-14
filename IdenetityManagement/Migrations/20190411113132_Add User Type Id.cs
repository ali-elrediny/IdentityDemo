using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Identity.Migrations
{
    public partial class AddUserTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "AspNetUsers");
        }
    }
}
