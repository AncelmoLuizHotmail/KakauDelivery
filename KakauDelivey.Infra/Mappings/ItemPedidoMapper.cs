using KakauDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KakauDelivey.Infra.Mappings
{
    public class ItemPedidoMapper : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItensPedido");

            builder.HasKey(ip => ip.Id);

            builder.Property(ip => ip.Quantidade)
                .IsRequired();

            builder.Property(ip => ip.IdProduto)
                .IsRequired();

            builder.Property(ip => ip.IdPedido)
                .IsRequired();
        }
    }
}
