using Task2.Domain.Entities;

namespace Task2.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressQueryResponse
    {
        public Address Address { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
