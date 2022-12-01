﻿// <auto-generated />
using System;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(SGIContext))]
    [Migration("20221129012404_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Congregacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar (100)");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<int>("IdMatriz")
                        .HasColumnType("int");

                    b.Property<string>("NomeCongregacao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.HasIndex("IdMatriz");

                    b.ToTable("Congregacao", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int?>("IdCongregracao")
                        .HasColumnType("int");

                    b.Property<int?>("IdMatriz")
                        .HasColumnType("int");

                    b.Property<int?>("IdMenbro")
                        .HasColumnType("int");

                    b.Property<int>("TipoLacamento")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("IdCongregracao");

                    b.HasIndex("IdMatriz");

                    b.HasIndex("IdMenbro");

                    b.ToTable("Lancamento", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Matriz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar (100)");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("NomeMatriz")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.ToTable("Matriz", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Membro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime?>("DataBatismoAgua")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EGenero")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdCongregracao")
                        .HasColumnType("int");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<int?>("IdMatriz")
                        .HasColumnType("int");

                    b.Property<string>("Mae")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Pai")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Whatsapp")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("IdCongregracao");

                    b.HasIndex("IdEndereco");

                    b.HasIndex("IdMatriz");

                    b.ToTable("Membro", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TipoPerfil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Perfil", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Domain.Models.UsuarioPerfil", b =>
                {
                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("char(36)");

                    b.HasKey("IdPerfil", "IdUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsuarioPerfil", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Congregacao", b =>
                {
                    b.HasOne("Domain.Models.Endereco", "Endereco")
                        .WithMany("Congregracoes")
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Matriz", "Matriz")
                        .WithMany("Congregracaoes")
                        .HasForeignKey("IdMatriz")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Matriz");
                });

            modelBuilder.Entity("Domain.Models.Lancamento", b =>
                {
                    b.HasOne("Domain.Models.Congregacao", "Congregracao")
                        .WithMany("Lancamentos")
                        .HasForeignKey("IdCongregracao");

                    b.HasOne("Domain.Models.Matriz", "Matriz")
                        .WithMany("Lancamentos")
                        .HasForeignKey("IdMatriz");

                    b.HasOne("Domain.Models.Membro", "Membro")
                        .WithMany("Lancamentos")
                        .HasForeignKey("IdMenbro");

                    b.Navigation("Congregracao");

                    b.Navigation("Matriz");

                    b.Navigation("Membro");
                });

            modelBuilder.Entity("Domain.Models.Matriz", b =>
                {
                    b.HasOne("Domain.Models.Endereco", "Endereco")
                        .WithMany("Matrizes")
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Domain.Models.Membro", b =>
                {
                    b.HasOne("Domain.Models.Congregacao", "Congregracao")
                        .WithMany("Membros")
                        .HasForeignKey("IdCongregracao");

                    b.HasOne("Domain.Models.Endereco", "Endereco")
                        .WithMany("Membros")
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Matriz", "Matriz")
                        .WithMany("Membros")
                        .HasForeignKey("IdMatriz");

                    b.Navigation("Congregracao");

                    b.Navigation("Endereco");

                    b.Navigation("Matriz");
                });

            modelBuilder.Entity("Domain.Models.UsuarioPerfil", b =>
                {
                    b.HasOne("Domain.Models.Perfil", "Perfil")
                        .WithMany("UsuarioPerfis")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Usuario", "Usuario")
                        .WithMany("UsuarioPerfis")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.Congregacao", b =>
                {
                    b.Navigation("Lancamentos");

                    b.Navigation("Membros");
                });

            modelBuilder.Entity("Domain.Models.Endereco", b =>
                {
                    b.Navigation("Congregracoes");

                    b.Navigation("Matrizes");

                    b.Navigation("Membros");
                });

            modelBuilder.Entity("Domain.Models.Matriz", b =>
                {
                    b.Navigation("Congregracaoes");

                    b.Navigation("Lancamentos");

                    b.Navigation("Membros");
                });

            modelBuilder.Entity("Domain.Models.Membro", b =>
                {
                    b.Navigation("Lancamentos");
                });

            modelBuilder.Entity("Domain.Models.Perfil", b =>
                {
                    b.Navigation("UsuarioPerfis");
                });

            modelBuilder.Entity("Domain.Models.Usuario", b =>
                {
                    b.Navigation("UsuarioPerfis");
                });
#pragma warning restore 612, 618
        }
    }
}
