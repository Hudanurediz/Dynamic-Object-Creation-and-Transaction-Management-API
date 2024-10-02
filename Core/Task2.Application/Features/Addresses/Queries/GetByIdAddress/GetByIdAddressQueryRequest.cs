using MediatR;

namespace Task2.Application.Features.Addresses.Queries.GetByIdAddress
{
    public class GetByIdAddressQueryRequest:IRequest<GetByIdAddressQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
