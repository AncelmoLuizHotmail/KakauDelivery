using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KakauDelivey.Infra.Mappings
{
    public class UsuarioMapper : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(u => u.SenhaHash)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(u => u.Perfil)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<PerfilUsuarioEnum>());


            builder.HasOne(u => u.Cliente)
                .WithMany()
                .HasForeignKey(u => u.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
