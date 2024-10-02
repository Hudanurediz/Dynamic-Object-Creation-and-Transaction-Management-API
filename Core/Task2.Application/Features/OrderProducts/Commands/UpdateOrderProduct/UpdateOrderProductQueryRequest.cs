using MediatR;

namespace Task2.Application.Features.OrderProducts.Commands.UpdateOrderProduct
{
    public class UpdateOrderProductQueryRequest:IRequest<UpdateOrderProductQueryResponse>
    {
        public Guid Id { get; set; }

        public Guid? ProductId { get; set; }

        public int? Quantity { get; set; }

        public Guid? OrderId { get; set; }

    }
}
