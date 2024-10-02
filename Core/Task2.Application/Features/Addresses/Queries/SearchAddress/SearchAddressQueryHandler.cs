using MediatR;
using Task2.Application.Abstractions;

namespace Task2.Application.Features.Addresses.Queries.SearchAddress
{
    public class SearchAddressQueryHandler : IRequestHandler<SearchAddressQueryRequest, SearchAddressQueryResponse>
    {
        readonly private IAddressReadRepository _addressReadRepository;

        public SearchAddressQueryHandler(IAddressReadRepository addressReadRepository)
        {
            _addressReadRepository = addressReadRepository;
        }

        public async Task<SearchAddressQueryResponse> Handle(SearchAddressQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var addresses = await _addressReadRepository.SearchAsync(request.Property);

                Console.WriteLine(addresses);

                return new SearchAddressQueryResponse
                {
                    Addresses = addresses,
                    Success = true,
                    Message = "Addresses retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
