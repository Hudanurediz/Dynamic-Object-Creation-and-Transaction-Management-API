using Task2.Application.Features.Orders.Commands.CreateOrder;
using Task2.Domain.Entities;

namespace Task2.Application.Abstractions
{
    public interface IOrderWriteRepository:IWriteRepository<Order>
    {

        Task CreateOrderWithTransactionAsync(CreateOrderQueryRequest request);

    }
}
