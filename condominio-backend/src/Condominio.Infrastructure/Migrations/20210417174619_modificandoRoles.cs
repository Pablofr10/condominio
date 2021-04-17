using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Infrastructure.Migrations
{
    public partial class modificandoRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "AspNetUserRoles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AspNetUserRoles",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "AspNetUserRoles");
        }
    }
}
