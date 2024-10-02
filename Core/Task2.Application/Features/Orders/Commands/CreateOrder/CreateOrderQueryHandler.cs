using MediatR;
using Task2.Application.Abstractions;

namespace Task2.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderQueryHandler : IRequestHandler<CreateOrderQueryRequest, CreateOrderQueryResponse>
    {
        readonly private IOrderWriteRepository _orderWriteRepository;

        public CreateOrderQueryHandler(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }
        public async Task<CreateOrderQueryResponse> Handle(CreateOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _orderWriteRepository.CreateOrderWithTransactionAsync(request);
                return new CreateOrderQueryResponse
                {
                    Success = true,
                    Message = "Order created successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateOrderQueryResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
