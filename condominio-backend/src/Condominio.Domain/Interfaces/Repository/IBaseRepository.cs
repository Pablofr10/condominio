using System.Threading.Tasks;

namespace Condominio.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}