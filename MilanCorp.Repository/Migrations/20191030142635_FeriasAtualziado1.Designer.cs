﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilanCorp.Repository;

namespace MilanCorp.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191030142635_FeriasAtualziado1")]
    partial class FeriasAtualziado1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MilanCorp.Domain.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("MilanCorp.Domain.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Cargo");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Data");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<bool>("UserAD");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MilanCorp.Domain.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.Aniversariante", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ativo");

                    b.Property<DateTime?>("start");

                    b.Property<string>("title");

                    b.HasKey("id");

                    b.ToTable("Aniversariantes");
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("end");

                    b.Property<bool?>("finished");

                    b.Property<DateTime?>("start");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.EventoLeilao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("endereco");

                    b.Property<string>("nomeDoComitente");

                    b.Property<string>("observacao");

                    b.Property<DateTime?>("start");

                    b.Property<string>("tipoDeLeilao");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.ToTable("EventosLeiloes");
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.Ferias", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cargo");

                    b.Property<DateTime>("DataDaSolicitacao");

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Expirar");

                    b.Property<string>("NomeDoFuncionario");

                    b.Property<string>("Observacao");

                    b.Property<int>("QuantidadeDeDias");

                    b.Property<string>("Ramal");

                    b.Property<string>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Ferias");
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.FileUpload", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ano");

                    b.Property<DateTime>("data");

                    b.Property<string>("nomeDaNota");

                    b.Property<string>("pasta");

                    b.Property<string>("termoDeAceite");

                    b.Property<string>("type");

                    b.HasKey("Id");

                    b.ToTable("Uploads");
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.Material", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("UploadId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("DataEmissao");

                    b.Property<string>("Descricao");

                    b.Property<string>("NumeroDaNota");

                    b.Property<int?>("Quantidade");

                    b.Property<decimal?>("Valor");

                    b.Property<decimal?>("ValorTotal");

                    b.HasKey("Id", "UploadId", "UserId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("UploadId");

                    b.HasIndex("UserId");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.Notificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Assunto");

                    b.Property<DateTime>("Data");

                    b.Property<DateTime>("DataDaSolicitacao");

                    b.Property<int>("Expirar");

                    b.HasKey("Id");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.Reuniao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<DateTime?>("data");

                    b.Property<string>("departamento")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("end");

                    b.Property<int>("local");

                    b.Property<int>("sala");

                    b.Property<DateTime>("start");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reunioes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("MilanCorp.Domain.Identity.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("MilanCorp.Domain.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("MilanCorp.Domain.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("MilanCorp.Domain.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilanCorp.Domain.Identity.UserRole", b =>
                {
                    b.HasOne("MilanCorp.Domain.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MilanCorp.Domain.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.Ferias", b =>
                {
                    b.HasOne("MilanCorp.Domain.Identity.User", "User")
                        .WithMany("Ferias")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.Material", b =>
                {
                    b.HasOne("MilanCorp.Domain.Models.FileUpload", "Upload")
                        .WithMany("Materiais")
                        .HasForeignKey("UploadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MilanCorp.Domain.Identity.User", "Usuario")
                        .WithMany("Materiais")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilanCorp.Domain.Models.Reuniao", b =>
                {
                    b.HasOne("MilanCorp.Domain.Identity.User", "User")
                        .WithMany("Reunioes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
