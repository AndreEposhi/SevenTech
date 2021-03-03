using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevenTech.Domain.Models;

namespace SevenTech.Infra.Mappings
{
 
    /// <summary>
    /// Mapeamento da entidade de endereço
    /// </summary>
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.DataCadastro)
                .IsRequired();
            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Complemento)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(p => p.Cep)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}