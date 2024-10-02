using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Domain.Entities.Common;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> Table;


        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
            Table = _context.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAllAsync(bool tracking = true)
        {
            try
            {
                var query = Table.AsQueryable();

                query = query.Where(data => data.DeletedDate == null);

                if (!tracking)
                    query = query.AsNoTracking();

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
        {
            try
            {
                var query = Table.AsQueryable();

                query = query.Where(data => data.DeletedDate == null);

                if (!tracking)
                    query = query.AsNoTracking();

                return await query.FirstOrDefaultAsync(data => data.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {

            try
            {
                return await _context.Set<T>()
                                     .Where(data => data.DeletedDate == null)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
