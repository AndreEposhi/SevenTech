using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevenTech.Domain.Models;

namespace SevenTech.Infra.Mappings
{
    /// <summary>
    /// Mapeamento da entidade de cliente
    /// </summary>
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(p => p.DataNascimento)
                .IsRequired();
            builder.Property(p => p.DataNascimento)
                .IsRequired();
            builder.Property(p => p.Sexo)
                .IsRequired()
                .HasConversion<int>();
            builder.HasOne(h => h.Endereco)
                .WithOne(h => h.Cliente);
        }
    }
}