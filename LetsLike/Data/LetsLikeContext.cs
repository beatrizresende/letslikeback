
using LetsLike.Configurations;
using LetsLike.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Data
{
    public class LetsLikeContext : DbContext
    {
        // TODO instância das models no db
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<UsuarioLikeProjeto> UsuariosLikeProjetos { get; set; }
        public LetsLikeContext(DbContextOptions<LetsLikeContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                   var connection = @"Server=A4APHKB\\SQLEXPRESS;Database=LetsLike;Trusted_Connection=True;";

                optionsBuilder.UseSqlServer(connection);
            }
        }

        // todo método que modela as configurations que criamos na pasta configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // todo ApplyConfiguration aplica as configurações de entidade que criamos
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProjetoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioLikeProjetoConfiguration());
        }
    }
}
