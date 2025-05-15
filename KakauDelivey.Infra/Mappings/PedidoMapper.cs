using KakauDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KakauDelivey.Infra.Mappings
{
    public class PedidoMapper : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.IdCliente)
                .HasDatabaseName("IX_Pedidos_IdCliente");

            builder.HasIndex(p => new { p.Status, p.DataPedido });

            builder.Property(p => p.IdCliente)
                .IsRequired();

            builder.Property(p => p.DataPedido)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.Status)
                .IsRequired();

            builder.HasMany(p => p.Itens)
                .WithOne(ip => ip.Pedido)
                .HasForeignKey(ip => ip.IdPedido);
        }
    }
}
