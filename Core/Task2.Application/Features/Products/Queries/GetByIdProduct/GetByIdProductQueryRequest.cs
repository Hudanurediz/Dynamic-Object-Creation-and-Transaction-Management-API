using MediatR;

namespace Task2.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQueryRequest:IRequest<GetByIdProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
