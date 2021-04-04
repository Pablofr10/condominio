using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Repository.Migrations
{
    public partial class corrigindoImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_tb_imagem_IdImagem",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "tb_imagem");

            migrationBuilder.RenameColumn(
                name: "IdImagem",
                table: "tb_usuario",
                newName: "id_imagem");

            migrationBuilder.RenameIndex(
                name: "IX_tb_usuario_IdImagem",
                table: "tb_usuario",
                newName: "IX_tb_usuario_id_imagem");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_tb_imagem_id_imagem",
                table: "tb_usuario",
                column: "id_imagem",
                principalTable: "tb_imagem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_tb_imagem_id_imagem",
                table: "tb_usuario");

            migrationBuilder.RenameColumn(
                name: "id_imagem",
                table: "tb_usuario",
                newName: "IdImagem");

            migrationBuilder.RenameIndex(
                name: "IX_tb_usuario_id_imagem",
                table: "tb_usuario",
                newName: "IX_tb_usuario_IdImagem");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "tb_imagem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_tb_imagem_IdImagem",
                table: "tb_usuario",
                column: "IdImagem",
                principalTable: "tb_imagem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
