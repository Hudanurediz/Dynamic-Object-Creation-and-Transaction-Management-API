using MediatR;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderQueryRequest:IRequest<UpdateOrderQueryResponse>
    {
        public Guid Id { get; set; }

        public Guid? CustomerId { get; set; }

        public string? Status { get; set; }

        public string? TrackingNumber { get; set; }

        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
