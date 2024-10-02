using MediatR;

namespace Task2.Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressQueryRequest:IRequest<DeleteAddressQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
