using Microsoft.EntityFrameworkCore;

namespace Task2.Application.Abstractions
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
    }
}
