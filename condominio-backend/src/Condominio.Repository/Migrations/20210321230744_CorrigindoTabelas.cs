using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Repository.Migrations
{
    public partial class CorrigindoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_imagem_tb_usuario_UsuarioId",
                table: "tb_imagem");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_visitante_tb_usuario_UsuarioId",
                table: "tb_visitante");

            migrationBuilder.DropIndex(
                name: "IX_tb_visitante_UsuarioId",
                table: "tb_visitante");

            migrationBuilder.DropIndex(
                name: "IX_tb_imagem_UsuarioId",
                table: "tb_imagem");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "tb_visitante");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tb_visitante");

            migrationBuilder.DropColumn(
                name: "data_visita",
                table: "tb_visitante");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "tb_reserva");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "tb_imagem");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tb_imagem");

            migrationBuilder.RenameColumn(
                name: "IdReserva",
                table: "tb_usuario",
                newName: "id_imagem");

            migrationBuilder.CreateTable(
                name: "tb_usuario_visitante",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    id_visitante = table.Column<int>(type: "integer", nullable: false),
                    data_visita = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario_visitante", x => new { x.id_usuario, x.id_visitante });
                    table.ForeignKey(
                        name: "FK_tb_usuario_visitante_tb_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "tb_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_usuario_visitante_tb_visitante_id_visitante",
                        column: x => x.id_visitante,
                        principalTable: "tb_visitante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_id_imagem",
                table: "tb_usuario",
                column: "id_imagem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_visitante_id_visitante",
                table: "tb_usuario_visitante",
                column: "id_visitante");

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

            migrationBuilder.DropTable(
                name: "tb_usuario_visitante");

            migrationBuilder.DropIndex(
                name: "IX_tb_usuario_id_imagem",
                table: "tb_usuario");

            migrationBuilder.RenameColumn(
                name: "id_imagem",
                table: "tb_usuario",
                newName: "IdReserva");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "tb_visitante",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "tb_visitante",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "data_visita",
                table: "tb_visitante",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "tb_reserva",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "tb_imagem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "tb_imagem",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_visitante_UsuarioId",
                table: "tb_visitante",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_imagem_UsuarioId",
                table: "tb_imagem",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_imagem_tb_usuario_UsuarioId",
                table: "tb_imagem",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_visitante_tb_usuario_UsuarioId",
                table: "tb_visitante",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
