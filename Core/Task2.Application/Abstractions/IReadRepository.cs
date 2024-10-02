namespace Task2.Application.Abstractions
{
    public interface IReadRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(bool tracking = true);

        Task<T> GetByIdAsync(Guid id, bool tracking = true);

        Task<IEnumerable<T>> GetAllAsync();

    }
}
