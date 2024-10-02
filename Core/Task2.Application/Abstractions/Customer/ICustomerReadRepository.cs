using Task2.Domain.Entities;

namespace Task2.Application.Abstractions
{
    public interface ICustomerReadRepository:IReadRepository<Customer>
    {
        Task<List<Customer>> SearchAsync(string filter);

    }
}
