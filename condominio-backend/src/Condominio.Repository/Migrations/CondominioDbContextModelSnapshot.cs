﻿// <auto-generated />
using System;
using Condominio.Repository.Commom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Condominio.Repository.Migrations
{
    [DbContext(typeof(CondominioDbContext))]
    partial class CondominioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Condominio.Domain.Entities.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("celular");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("tb_contato");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Convidado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Confirmado")
                        .HasColumnType("boolean")
                        .HasColumnName("confirmado");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<int>("IdReserva")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.ToTable("tb_convidado");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Imagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("local");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tb_imagem");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_reserva");

                    b.Property<DateTime>("HoraFinal")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("hora_final");

                    b.Property<DateTime>("HoraInicial")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("hora_inicial");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("local");

                    b.Property<int>("QuantidadeConvidados")
                        .HasColumnType("integer")
                        .HasColumnName("quantidade_convidados");

                    b.Property<int>("Situacao")
                        .HasColumnType("integer")
                        .HasColumnName("situacao");

                    b.HasKey("Id");

                    b.ToTable("tb_reserva");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("complementoReserva");

                    b.Property<int?>("ContatoId")
                        .HasColumnType("integer");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("IdContato")
                        .HasColumnType("integer")
                        .HasColumnName("id_contato");

                    b.Property<int>("IdReserva")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<int>("NumeroApartamento")
                        .HasColumnType("integer")
                        .HasColumnName("numero_apartamento");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.ToTable("tb_clience");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.UsuarioReserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdReserva")
                        .HasColumnType("integer")
                        .HasColumnName("id_reserva");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer")
                        .HasColumnName("id_usuario");

                    b.HasKey("Id");

                    b.HasIndex("IdReserva");

                    b.HasIndex("IdUsuario");

                    b.ToTable("tb_usuario_reserva");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Visitante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Confirmado")
                        .HasColumnType("boolean")
                        .HasColumnName("confirmado");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("DataVisita")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("data_visita");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tb_visitante");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Convidado", b =>
                {
                    b.HasOne("Condominio.Domain.Entities.Reserva", "Reserva")
                        .WithMany()
                        .HasForeignKey("ReservaId");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Imagem", b =>
                {
                    b.HasOne("Condominio.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Condominio.Domain.Entities.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId");

                    b.Navigation("Contato");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.UsuarioReserva", b =>
                {
                    b.HasOne("Condominio.Domain.Entities.Reserva", "Reserva")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Condominio.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Visitante", b =>
                {
                    b.HasOne("Condominio.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Reserva", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
