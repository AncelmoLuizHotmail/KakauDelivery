using KakauDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                .HasConversion<string>();


            builder.HasOne(u => u.Cliente)
                .WithOne(c => c.Usuario)
                .HasForeignKey<Cliente>(c => c.IdUsuario)
                .IsRequired();
        }
    }
}
