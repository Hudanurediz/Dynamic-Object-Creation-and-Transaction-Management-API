using MediatR;
using Task2.Application.Abstractions;

namespace Task2.Application.Features.Products.Queries.SearchProduct
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQueryRequest, SearchProductQueryResponse>
    {
        readonly private IProductReadRepository _productReadRepository;

        public SearchProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task<SearchProductQueryResponse> Handle(SearchProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productReadRepository.SearchAsync(request.Property);

                return new SearchProductQueryResponse
                {
                    Products = products,
                    Success = true,
                    Message = "Orders retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
