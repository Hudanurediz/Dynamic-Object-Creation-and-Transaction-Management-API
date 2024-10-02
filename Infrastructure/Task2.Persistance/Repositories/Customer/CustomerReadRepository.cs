using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Domain.Entities;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Customer>> SearchAsync(string filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter))
                {
                    return await _context.Customers.ToListAsync();
                }

                return await _context.Customers
                    .Where(customer => customer.FirstName.Contains(filter) ||
                                     customer.LastName.Contains(filter) ||
                                     customer.UserName.Contains(filter) ||
                                     customer.Email.Contains(filter) ||
                                     customer.PhoneNumber.Contains(filter))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
