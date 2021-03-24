using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Repository.Migrations
{
    public partial class AtualizandoBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_clience_tb_contato_ContatoId",
                table: "tb_clience");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_imagem_tb_clience_UsuarioId",
                table: "tb_imagem");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_reserva_tb_clience_id_usuario",
                table: "tb_usuario_reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_visitante_tb_clience_UsuarioId",
                table: "tb_visitante");

            migrationBuilder.DropTable(
                name: "tb_convidado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario_reserva",
                table: "tb_usuario_reserva");

            migrationBuilder.DropIndex(
                name: "IX_tb_usuario_reserva_id_reserva",
                table: "tb_usuario_reserva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_clience",
                table: "tb_clience");

            migrationBuilder.DropIndex(
                name: "IX_tb_clience_ContatoId",
                table: "tb_clience");

            migrationBuilder.DropColumn(
                name: "id",
                table: "tb_usuario_reserva");

            migrationBuilder.DropColumn(
                name: "ContatoId",
                table: "tb_clience");

            migrationBuilder.RenameTable(
                name: "tb_clience",
                newName: "tb_usuario");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "tb_contato",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario_reserva",
                table: "tb_usuario_reserva",
                columns: new[] { "id_reserva", "id_usuario" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_imagem_tb_usuario_UsuarioId",
                table: "tb_imagem",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_reserva_tb_usuario_id_usuario",
                table: "tb_usuario_reserva",
                column: "id_usuario",
                principalTable: "tb_usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_visitante_tb_usuario_UsuarioId",
                table: "tb_visitante",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_contato_tb_usuario_IdUsuario",
                table: "tb_contato");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_imagem_tb_usuario_UsuarioId",
                table: "tb_imagem");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_reserva_tb_usuario_id_usuario",
                table: "tb_usuario_reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_visitante_tb_usuario_UsuarioId",
                table: "tb_visitante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario_reserva",
                table: "tb_usuario_reserva");

            migrationBuilder.DropIndex(
                name: "IX_tb_contato_IdUsuario",
                table: "tb_contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "tb_contato");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "tb_clience");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "tb_usuario_reserva",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ContatoId",
                table: "tb_clience",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario_reserva",
                table: "tb_usuario_reserva",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_clience",
                table: "tb_clience",
                column: "id");

            migrationBuilder.CreateTable(
                name: "tb_convidado",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    confirmado = table.Column<bool>(type: "boolean", nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    IdReserva = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ReservaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_convidado", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_convidado_tb_reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "tb_reserva",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_reserva_id_reserva",
                table: "tb_usuario_reserva",
                column: "id_reserva");

            migrationBuilder.CreateIndex(
                name: "IX_tb_clience_ContatoId",
                table: "tb_clience",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_convidado_ReservaId",
                table: "tb_convidado",
                column: "ReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_clience_tb_contato_ContatoId",
                table: "tb_clience",
                column: "ContatoId",
                principalTable: "tb_contato",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_imagem_tb_clience_UsuarioId",
                table: "tb_imagem",
                column: "UsuarioId",
                principalTable: "tb_clience",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_reserva_tb_clience_id_usuario",
                table: "tb_usuario_reserva",
                column: "id_usuario",
                principalTable: "tb_clience",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_visitante_tb_clience_UsuarioId",
                table: "tb_visitante",
                column: "UsuarioId",
                principalTable: "tb_clience",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
