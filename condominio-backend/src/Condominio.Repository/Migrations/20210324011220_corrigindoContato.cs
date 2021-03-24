using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Repository.Migrations
{
    public partial class corrigindoContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_contato_tb_usuario_IdUsuario",
                table: "tb_contato");

            migrationBuilder.DropIndex(
                name: "IX_tb_contato_IdUsuario",
                table: "tb_contato");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "tb_contato");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_id_contato",
                table: "tb_usuario",
                column: "id_contato",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_tb_contato_id_contato",
                table: "tb_usuario",
                column: "id_contato",
                principalTable: "tb_contato",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_tb_contato_id_contato",
                table: "tb_usuario");

            migrationBuilder.DropIndex(
                name: "IX_tb_usuario_id_contato",
                table: "tb_usuario");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "tb_contato",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_contato_IdUsuario",
                table: "tb_contato",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_contato_tb_usuario_IdUsuario",
                table: "tb_contato",
                column: "IdUsuario",
                principalTable: "tb_usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
