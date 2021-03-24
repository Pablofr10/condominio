using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_contato",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    telefone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    celular = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_contato", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_reserva",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    local = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    data_reserva = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    hora_inicial = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    hora_final = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    quantidade_convidados = table.Column<int>(type: "integer", nullable: false),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_reserva", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_clience",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    numero_apartamento = table.Column<int>(type: "integer", nullable: false),
                    complementoReserva = table.Column<string>(type: "text", nullable: false),
                    id_contato = table.Column<int>(type: "integer", nullable: false),
                    ContatoId = table.Column<int>(type: "integer", nullable: true),
                    IdReserva = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_clience", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_clience_tb_contato_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "tb_contato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_convidado",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    confirmado = table.Column<bool>(type: "boolean", nullable: false),
                    IdReserva = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "tb_imagem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    local = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_imagem", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_imagem_tb_clience_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_clience",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario_reserva",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    id_reserva = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario_reserva", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_usuario_reserva_tb_clience_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "tb_clience",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_usuario_reserva_tb_reserva_id_reserva",
                        column: x => x.id_reserva,
                        principalTable: "tb_reserva",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_visitante",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    data_visita = table.Column<string>(type: "text", nullable: false),
                    confirmado = table.Column<bool>(type: "boolean", nullable: false),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_visitante", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_visitante_tb_clience_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_clience",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_clience_ContatoId",
                table: "tb_clience",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_convidado_ReservaId",
                table: "tb_convidado",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_imagem_UsuarioId",
                table: "tb_imagem",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_reserva_id_reserva",
                table: "tb_usuario_reserva",
                column: "id_reserva");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_reserva_id_usuario",
                table: "tb_usuario_reserva",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_visitante_UsuarioId",
                table: "tb_visitante",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_convidado");

            migrationBuilder.DropTable(
                name: "tb_imagem");

            migrationBuilder.DropTable(
                name: "tb_usuario_reserva");

            migrationBuilder.DropTable(
                name: "tb_visitante");

            migrationBuilder.DropTable(
                name: "tb_reserva");

            migrationBuilder.DropTable(
                name: "tb_clience");

            migrationBuilder.DropTable(
                name: "tb_contato");
        }
    }
}
