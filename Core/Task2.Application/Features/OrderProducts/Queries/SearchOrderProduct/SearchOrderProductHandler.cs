using MediatR;
using Task2.Application.Abstractions;

namespace Task2.Application.Features.OrderProducts.Queries.SearchOrderProduct
{
    public class SearchOrderProductHandler : IRequestHandler<SearchOrderProductRequest, SearchOrderProductResponse>
    {
        readonly private IOrderProductReadRepository _orderProductReadRepository;

        public SearchOrderProductHandler(IOrderProductReadRepository orderProductReadRepository)
        {
            _orderProductReadRepository = orderProductReadRepository;
        }

        public async Task<SearchOrderProductResponse> Handle(SearchOrderProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orderProducts = await _orderProductReadRepository.SearchAsync(request.Property);

                return new SearchOrderProductResponse
                {
                    OrderProducts = orderProducts,
                    Success = true,
                    Message = "Order Product retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
