using KakauDelivery.Domain.Entities;
using KakauDelivey.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace KakauDelivey.Infra.KakauDeliveryContext
{
    public class KakauDeliveryDbContext : DbContext
    {
        public KakauDeliveryDbContext(DbContextOptions<KakauDeliveryDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapper());
            modelBuilder.ApplyConfiguration(new ProdutoMapper());
            modelBuilder.ApplyConfiguration(new PedidoMapper());
            modelBuilder.ApplyConfiguration(new ItemPedidoMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}
