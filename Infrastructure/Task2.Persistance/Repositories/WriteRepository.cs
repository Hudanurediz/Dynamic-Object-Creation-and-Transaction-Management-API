using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Domain.Entities.Common;
using Task2.Persistance.Contexts;
using Task2.Application.Exceptions;

namespace Task2.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> Table;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
            Table = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                var newEntityEntry = await Table.AddAsync(entity);
                await _context.SaveChangesAsync();
                return newEntityEntry.Entity;
            }
            catch (DbUpdateException dbEx)
            {
                throw new DatabaseConnectionException("Failed to save the entity due to database connection issues.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the entity: " + ex.Message, ex);
            }
        }


        public bool Delete(Guid id)
        {
            try
            {
                var existingEntity = Table.SingleOrDefault(e => e.Id == id && e.DeletedDate == null);
                if (existingEntity == null)
                {
                    throw new ArgumentException($"Entity with ID {id} does not exist or has been deleted.");
                }

                // Soft delete işlemi
                existingEntity.DeletedDate = DateTime.UtcNow;
                _context.Entry(existingEntity).State = EntityState.Modified;

                var changes = _context.SaveChanges();
                return changes > 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Exception: {ex.Message}");
                throw; // Hatayı fırlatmaya devam et
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }



        public async Task<int> SaveAsync()
        {
            try
            {
                var status = await _context.SaveChangesAsync();
                return status;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool Update(Guid id, T entity)
        {
            try
            {
                var existingEntity = Table.Find(id);
                if (existingEntity == null)
                {
                    throw new ArgumentException("Entity is not exist."); ;
                }
                entity.Id = existingEntity.Id;

                _context.Entry(existingEntity).CurrentValues.SetValues(entity);

                var updated = _context.SaveChanges();
                if (updated > 0)
                {
                    existingEntity.UpdatedDate=DateTime.UtcNow;
                }
                return updated > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
