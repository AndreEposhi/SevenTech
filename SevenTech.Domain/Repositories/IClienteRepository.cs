using SevenTech.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SevenTech.Domain.Repositories
{
    /// <summary>
    /// Repositório da entidade de cliente
    /// </summary>
    public interface IClienteRepository
    {
        void Add(Cliente cliente);

        void Delete(Cliente cliente);

        Task<IEnumerable<Cliente>> GetAll();

        Task<Cliente> GetById(int id);

        void Update(Cliente cliente);
    }
}