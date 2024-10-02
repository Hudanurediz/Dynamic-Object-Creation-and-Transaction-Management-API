using MediatR;

namespace Task2.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressQueryRequest:IRequest<UpdateAddressQueryResponse>
    {
        public Guid Id { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public Guid CustomerId { get; set; }

        public bool? IsNewAddress { get; set; }

        public bool? IsRemove { get; set; }
    }
}
