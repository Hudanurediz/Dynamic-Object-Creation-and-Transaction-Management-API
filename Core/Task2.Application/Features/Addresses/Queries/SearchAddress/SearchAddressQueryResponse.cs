using Task2.Domain.Entities;

namespace Task2.Application.Features.Addresses.Queries.SearchAddress
{
    public class SearchAddressQueryResponse
    {
        public List<Address> Addresses { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
