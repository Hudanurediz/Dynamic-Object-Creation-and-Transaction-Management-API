using MediatR;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderQueryRequest:IRequest<CreateOrderQueryResponse>
    {
        public Guid CustomerId { get; set; }

        public string Status { get; set; }

        public ICollection<OrderProduct>? OrderProducts { get; set; }

        public string TrackingNumber { get; set; }

    }
}
