using MediatR;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Domain.Entities;

namespace Task2.Application.Features.OrderProducts.Commands.CreateOrderProduct
{
    public class CreateOrderProductQueryHandler : IRequestHandler<CreateOrderProductQueryRequest, CreateOrderProductQueryResponse>
    {
        readonly private IOrderProductWriteRepository _orderProductWriteRepository;

        public CreateOrderProductQueryHandler(IOrderProductWriteRepository orderProductWriteRepository)
        {
            _orderProductWriteRepository = orderProductWriteRepository;
        }

        public async Task<CreateOrderProductQueryResponse> Handle(CreateOrderProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orderProduct = new OrderProduct(
                    request.ProductId,
                    request.OrderId,
                    request.Quantity
                );

                var newOrderProduct = await _orderProductWriteRepository.AddAsync(orderProduct);
                if (newOrderProduct != null)
                {
                    return new CreateOrderProductQueryResponse
                    {
                        OrderProduct = newOrderProduct,
                        Success = true,
                        Message = "Entity created successfully."
                    };
                }

                throw new InvalidOperationException("Failed to save the address entity.");
            }
            catch (DatabaseConnectionException dbEx)
            {
                throw new DatabaseConnectionException("Failed to update entity due to database connection issues.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating the address.", ex);
            }
        }
    }
}
