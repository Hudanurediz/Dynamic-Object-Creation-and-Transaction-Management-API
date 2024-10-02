using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Application.Features.Orders.Commands.DeleteOrder;

namespace Task2.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductQueryHandler : IRequestHandler<DeleteProductQueryRequest, DeleteProductQueryResponse>
    {
        readonly private IProductWriteRepository _productWriteRepository;

        public DeleteProductQueryHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }
        public async Task<DeleteProductQueryResponse> Handle(DeleteProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteResult = _productWriteRepository.Delete(request.Id);
                var response = new DeleteProductQueryResponse
                {
                    Success = deleteResult,
                    Message = deleteResult ? "Deletion is successful" : "Deletion failed"
                };

                return response;
            }
            catch (DbUpdateException dbEx)
            {
                throw new DatabaseConnectionException("Failed to update entity due to database connection issues.", dbEx);
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseConnectionException("Database connection error occurred.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}
