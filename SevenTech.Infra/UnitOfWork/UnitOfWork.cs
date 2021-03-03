using SevenTech.Domain.UnitOfWork;
using SevenTech.Infra.Data;
using System.Threading.Tasks;

namespace SevenTech.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
            => await _context.SaveChangesAsync() > 0;
    }
}