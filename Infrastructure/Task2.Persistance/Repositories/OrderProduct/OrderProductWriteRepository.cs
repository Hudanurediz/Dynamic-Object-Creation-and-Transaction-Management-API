using Task2.Application.Abstractions;
using Task2.Domain.Entities;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class OrderProductWriteRepository : WriteRepository<OrderProduct>, IOrderProductWriteRepository
    {
        public OrderProductWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
