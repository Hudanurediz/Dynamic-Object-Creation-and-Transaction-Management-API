namespace Task2.Application.Abstractions
{
    public interface IWriteRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        bool Update(Guid id, T entity);

        bool Delete(Guid id);

        Task<int> SaveAsync();
    }
}
