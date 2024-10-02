using Task2.Domain.Entities;

namespace Task2.Application.Features.Addresses.Queries.GetByIdAddress
{
    public class GetByIdAddressQueryResponse
    {
        public Address? Address { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
