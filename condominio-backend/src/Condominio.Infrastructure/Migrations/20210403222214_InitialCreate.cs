using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_tb_imagem_id_imagem",
                table: "tb_usuario");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_usuario_reserva",
                newName: "Id");

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
                table: "tb_visitante",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "tb_usuario_reserva",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_tb_imagem_IdImagem",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "tb_visitante");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "tb_imagem");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_usuario_reserva",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdImagem",
                table: "tb_usuario",
                newName: "id_imagem");

            migrationBuilder.RenameIndex(
                name: "IX_tb_usuario_IdImagem",
                table: "tb_usuario",
                newName: "IX_tb_usuario_id_imagem");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "tb_usuario_reserva",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_tb_imagem_id_imagem",
                table: "tb_usuario",
                column: "id_imagem",
                principalTable: "tb_imagem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
