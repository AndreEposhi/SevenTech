using Microsoft.EntityFrameworkCore;
using SevenTech.Domain.Models;
using SevenTech.Infra.Mappings;

namespace SevenTech.Infra.Data
{
    /// <summary>
    /// Contexto da aplicação
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
        }
    }
}