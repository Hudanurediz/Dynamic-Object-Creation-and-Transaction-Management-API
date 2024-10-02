using MediatR;

namespace Task2.Application.Features.OrderProducts.Queries.GetByIdOrderProduct
{
    public class GetByIdOrderProductRequest:IRequest<GetByIdOrderProductResponse>
    {
        public Guid Id { get; set; }
    }
}
