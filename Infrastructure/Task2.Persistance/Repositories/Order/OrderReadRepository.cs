using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Domain.Entities;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> SearchAsync(string filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter))
                {
                    return await _context.Orders.ToListAsync();
                }

                return await _context.Orders
                    .Where(order => order.TrackingNumber.Contains(filter) ||
                                     order.Status.Contains(filter) ||
                                     order.TrackingNumber.Contains(filter))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
