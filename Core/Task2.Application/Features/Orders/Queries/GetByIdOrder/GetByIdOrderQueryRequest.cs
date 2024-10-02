using MediatR;

namespace Task2.Application.Features.Orders.Queries.GetByIdOrder
{
    public class GetByIdOrderQueryRequest:IRequest<GetByIdOrderQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
