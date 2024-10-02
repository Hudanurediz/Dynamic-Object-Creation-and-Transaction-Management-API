using Task2.Domain.Entities;

namespace Task2.Application.Abstractions
{
    public interface IAddressReadRepository:IReadRepository<Address>
    {
        Task<List<Address>> SearchAsync(string filter);
    }
}
