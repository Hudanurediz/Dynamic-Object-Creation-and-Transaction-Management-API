using MediatR;
using Task2.Application.Abstractions;

namespace Task2.Application.Features.Orders.Queries.SearchOrder
{
    public class SearchOrderQueryHandler : IRequestHandler<SearchOrderQueryRequest, SearchOrderQueryResponse>
    {
        readonly private IOrderReadRepository _orderReadRepository;

        public SearchOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }
        public async Task<SearchOrderQueryResponse> Handle(SearchOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _orderReadRepository.SearchAsync(request.Property);

                return new SearchOrderQueryResponse
                {
                    Orders = orders,
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
