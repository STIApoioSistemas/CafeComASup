﻿// <auto-generated />
using System;
using CafeComASup.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeComASup.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CafeComASup.Models.Confirmados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataConfirmacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataEnvioEmail")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Confirmados");
                });

            modelBuilder.Entity("CafeComASup.Models.Enquetes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Enquetes");
                });

            modelBuilder.Entity("CafeComASup.Models.Eventos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("UrlCapa")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("CafeComASup.Models.Funcionarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("Prontuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("CafeComASup.Models.RespostasEnquetes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnqueteId")
                        .HasColumnType("int");

                    b.Property<int>("OrdemPergunta")
                        .HasColumnType("int");

                    b.Property<string>("Pergunta")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("Resposta")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RespostasEnquetes");
                });
#pragma warning restore 612, 618
        }
    }
}
