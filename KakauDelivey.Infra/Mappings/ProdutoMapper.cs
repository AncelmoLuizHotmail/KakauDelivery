using KakauDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KakauDelivey.Infra.Mappings
{
    public class ProdutoMapper : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.TipoProduto)
                .IsRequired();

            builder.HasMany(p => p.ItensPedido)
                .WithOne(ip => ip.Produto)
                .HasForeignKey(ip => ip.IdProduto);
        }
    }
}
