using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task2.Application.Abstractions;
using Task2.Domain.Entities;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class AddressReadRepository : ReadRepository<Address>, IAddressReadRepository
    {
        public AddressReadRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Address>> SearchAsync(string filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter))
                {
                    return await _context.Addresses.ToListAsync();
                }

                return await _context.Addresses
                    .Where(address => address.Street.Contains(filter) ||
                                     address.City.Contains(filter) ||
                                     address.State.Contains(filter) ||
                                     address.PostalCode.Contains(filter) ||
                                     address.Country.Contains(filter))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
