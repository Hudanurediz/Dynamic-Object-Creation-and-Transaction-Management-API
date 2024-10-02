using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Domain.Entities;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class OrderProductReadRepository : ReadRepository<OrderProduct>, IOrderProductReadRepository
    {
        public OrderProductReadRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<OrderProduct>> SearchAsync(string filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter))
                {
                    return await _context.OrderProducts.ToListAsync();
                }

                return await _context.OrderProducts
                    .Where(OrderProduct => OrderProduct.Product.Name.Contains(filter) ||
                    OrderProduct.Product.BarcodeCode.Contains(filter)
                                )
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
