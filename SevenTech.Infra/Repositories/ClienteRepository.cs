using Microsoft.EntityFrameworkCore;
using SevenTech.Domain.Models;
using SevenTech.Domain.Repositories;
using SevenTech.Infra.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenTech.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Cliente cliente)
            => _context.Add(cliente);

        public void Delete(Cliente cliente)
            => _context.Remove(cliente);

        public async Task<IEnumerable<Cliente>> GetAll()
            => await _context.Clientes
                             .Include(i => i.Endereco)
                             .OrderBy(o => o.Nome)
                             .AsNoTracking()
                             .ToListAsync();

        public async Task<Cliente> GetById(int id)
            => await _context.Clientes
                             .Include(i => i.Endereco)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(f => f.Id == id);

        public void Update(Cliente entity)
            => _context.Update(entity);
    }
}