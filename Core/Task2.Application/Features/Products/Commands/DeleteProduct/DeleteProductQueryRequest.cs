using MediatR;

namespace Task2.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductQueryRequest:IRequest<DeleteProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
