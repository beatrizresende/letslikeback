﻿// <auto-generated />
using LetsLike.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LetsLike.Migrations
{
    [DbContext(typeof(LetsLikeContext))]
    partial class LetsLikeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LetsLike.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUsuarioCadastro")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IMAGEM");

                    b.Property<int>("LikeContador")
                        .HasColumnType("int")
                        .HasColumnName("LIKE_CONTADOR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("URL");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioCadastro");

                    b.ToTable("PROJETO");
                });

            modelBuilder.Entity("LetsLike.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SENHA");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("URSERNAME");

                    b.HasKey("Id");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("LetsLike.Models.UsuarioLikeProjeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProjetoLike")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROJETO_LIKE");

                    b.Property<int>("IdUsuarioLike")
                        .HasColumnType("int")
                        .HasColumnName("ID_USUARIO_LIKE");

                    b.HasKey("Id");

                    b.HasIndex("IdProjetoLike");

                    b.HasIndex("IdUsuarioLike");

                    b.ToTable("USUARIO_LIKE_PROJETO");
                });

            modelBuilder.Entity("LetsLike.Models.Projeto", b =>
                {
                    b.HasOne("LetsLike.Models.Usuario", "UsuarioCadastro")
                        .WithMany("Projeto")
                        .HasForeignKey("IdUsuarioCadastro")
                        .HasConstraintName("FK_PROJETO_USUARIO_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("LetsLike.Models.UsuarioLikeProjeto", b =>
                {
                    b.HasOne("LetsLike.Models.Projeto", "ProjetoLike")
                        .WithMany("ProjetoLikeUsuario")
                        .HasForeignKey("IdProjetoLike")
                        .HasConstraintName("FK_PROJETO_USUARIO_LIKE_PROJETO")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LetsLike.Models.Usuario", "UsuarioLike")
                        .WithMany("UsuarioLikeProjeto")
                        .HasForeignKey("IdUsuarioLike")
                        .HasConstraintName("FK_USUARIO_USUARIO_LIKE_PROJETO")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProjetoLike");

                    b.Navigation("UsuarioLike");
                });

            modelBuilder.Entity("LetsLike.Models.Projeto", b =>
                {
                    b.Navigation("ProjetoLikeUsuario");
                });

            modelBuilder.Entity("LetsLike.Models.Usuario", b =>
                {
                    b.Navigation("Projeto");

                    b.Navigation("UsuarioLikeProjeto");
                });
#pragma warning restore 612, 618
        }
    }
}
