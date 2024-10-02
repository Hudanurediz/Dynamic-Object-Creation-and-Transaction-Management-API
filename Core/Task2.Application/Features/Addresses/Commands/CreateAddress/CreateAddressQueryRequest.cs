using MediatR;

namespace Task2.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressQueryRequest : IRequest<CreateAddressQueryResponse>
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string? PostalCode { get; set; }

        public string Country { get; set; }

        public Guid CustomerId { get; set; }

    }
}
