using MediatR;

namespace Task2.Application.Features.Addresses.Queries.SearchAddress
{
    public class SearchAddressQueryRequest:IRequest<SearchAddressQueryResponse>
    {
        public string? Property { get; set; }
    }
}
