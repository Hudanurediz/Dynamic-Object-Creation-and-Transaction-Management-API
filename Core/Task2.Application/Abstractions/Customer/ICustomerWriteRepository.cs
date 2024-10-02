using Microsoft.EntityFrameworkCore.Storage;
using Task2.Application.Features.Customers.Commands.CreateCustomer;
using Task2.Domain.Entities;

namespace Task2.Application.Abstractions
{
    public interface ICustomerWriteRepository:IWriteRepository<Customer>
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CreateCustomerWithTransactionAsync(CreateCustomerQueryRequest request);


    }
}
