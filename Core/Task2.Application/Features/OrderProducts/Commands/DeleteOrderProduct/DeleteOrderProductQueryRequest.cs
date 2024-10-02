using MediatR;

namespace Task2.Application.Features.OrderProducts.Commands.DeleteOrderProduct
{
    public class DeleteOrderProductQueryRequest:IRequest<DeleteOrderProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
