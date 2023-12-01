using CafeComASup.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeComASup.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        #region DbSet
        public DbSet<Confirmados>? Confirmados { get; set; }
        public DbSet<Reservas>? Reservas { get; set; }
		public DbSet<Enquetes>? Enquetes { get; set; }
        public DbSet<Eventos>? Eventos { get; set; }
        public DbSet<Funcionarios>? Funcionarios { get; set; }
        public DbSet<RespostasEnquetes>? RespostasEnquetes { get; set; }
        #endregion
    }
}
