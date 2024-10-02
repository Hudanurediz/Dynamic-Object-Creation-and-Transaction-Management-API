using Task2.Domain.Entities;

namespace Task2.Application.Features.Addresses.Queries.GetAllAddresses
{
    public class GetAllAddressesQueryResponse
    {
        public List<Address> Addresses { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
