using Task2.Domain.Entities;

namespace Task2.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressQueryResponse
    {
        public Address? Address { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
