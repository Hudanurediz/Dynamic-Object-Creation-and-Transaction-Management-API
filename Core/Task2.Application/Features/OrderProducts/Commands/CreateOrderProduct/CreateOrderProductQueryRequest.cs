using MediatR;

namespace Task2.Application.Features.OrderProducts.Commands.CreateOrderProduct
{
    public class CreateOrderProductQueryRequest:IRequest<CreateOrderProductQueryResponse>
    {
        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }


    }
}
