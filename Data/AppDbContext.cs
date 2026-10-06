using Microsoft.EntityFrameworkCore;
using ControleDeFinancasPessoais.Models;

namespace ControleDeFinancasPessoais.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de precisão e chaves no EF Core
            modelBuilder.Entity<Transacao>()
                .Property(t => t.Valor)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}