using Task2.Domain.Entities;

namespace Task2.Application.Abstractions
{
    public interface IOrderReadRepository:IReadRepository<Order>
    {
        Task<List<Order>> SearchAsync(string filter);
    }
}
