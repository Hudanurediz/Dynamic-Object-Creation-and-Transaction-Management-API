using Task2.Domain.Entities;

namespace Task2.Application.Abstractions
{
    public interface IOrderProductReadRepository:IReadRepository<OrderProduct>
    {
        Task<List<OrderProduct>> SearchAsync(string filter);
    }
}
