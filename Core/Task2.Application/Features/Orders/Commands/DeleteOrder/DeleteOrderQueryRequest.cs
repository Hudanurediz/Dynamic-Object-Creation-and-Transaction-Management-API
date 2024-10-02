using MediatR;

namespace Task2.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderQueryRequest:IRequest<DeleteOrderQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
