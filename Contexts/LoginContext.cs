using login_webAPI.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace login_webAPI.Contexts
{
    public class LoginContext : DbContext
    {
        public DbSet<TipoUsuario>  TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
        {
            opBuilder.UseSqlServer("Server=DESKTOP-FVIJG8R\\SQLEXPRESS; Database=LoginDB; user ID=sa; pwd=senai@132");
            base.OnConfiguring(opBuilder);
        }

        protected override void OnModelCreating(ModelBuilder mdBuilder)
        {
            mdBuilder.Entity<TipoUsuario>();
            mdBuilder.Entity<Usuario>();

            base.OnModelCreating(mdBuilder);
        }
    }
}
