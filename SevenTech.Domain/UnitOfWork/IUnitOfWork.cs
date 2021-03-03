using System.Threading.Tasks;

namespace SevenTech.Domain.UnitOfWork
{
    /// <summary>
    /// Unidade de trabalho da aplicação
    /// </summary>
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}