using Microsoft.EntityFrameworkCore;
using System.Linq;
using Task2.Application.Abstractions;
using Task2.Domain.Entities;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> SearchAsync(string filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter))
                {
                    return await _context.Products.ToListAsync();
                }

                return await _context.Products
                    .Where(product => product.Name.Contains(filter) ||
                                     product.Description.Contains(filter) ||
                                     product.Category.Contains(filter) ||
                                     product.BarcodeCode.Contains(filter) ||
                                     product.Brand.Contains(filter))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
