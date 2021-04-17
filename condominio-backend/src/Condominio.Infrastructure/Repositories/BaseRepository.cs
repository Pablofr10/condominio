using System.Threading.Tasks;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces.Repository;
using Condominio.Infrastructure.Commom;

namespace Condominio.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CondominioDbContext _context;

        public BaseRepository(CondominioDbContext context)
        {
            _context = context;
        }
        
        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }
        
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        
    }
}