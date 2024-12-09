using _123Vendas.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Infra.Context
{
    public class VendasContext : DbContext
    {
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Item> Itens { get; set; }

        public VendasContext(DbContextOptions<VendasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venda>()
                .HasMany(v => v.Itens)
                .WithOne()
                .HasForeignKey(vi => vi.VendaId);
        }
    }
}
