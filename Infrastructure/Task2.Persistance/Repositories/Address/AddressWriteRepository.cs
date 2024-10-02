using Task2.Application.Abstractions;
using Task2.Domain.Entities;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class AddressWriteRepository : WriteRepository<Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
