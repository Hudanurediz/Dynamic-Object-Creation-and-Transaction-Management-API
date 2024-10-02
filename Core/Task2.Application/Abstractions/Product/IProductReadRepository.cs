using Task2.Domain.Entities;

namespace Task2.Application.Abstractions
{
    public interface IProductReadRepository:IReadRepository<Product>
    {
        Task<List<Product>> SearchAsync(string filter);

    }
}
