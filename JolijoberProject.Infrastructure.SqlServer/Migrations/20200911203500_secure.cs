using Microsoft.EntityFrameworkCore.Migrations;

namespace JolijoberProject.Infrastructure.SqlServer.Migrations
{
    public partial class secure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecurId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SecurId",
                table: "AspNetUsers",
                column: "SecurId",
                unique: true,
                filter: "[SecurId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SecurId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurId",
                table: "AspNetUsers");
        }
    }
}
