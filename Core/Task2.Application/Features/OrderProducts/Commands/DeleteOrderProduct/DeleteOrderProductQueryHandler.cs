using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;

namespace Task2.Application.Features.OrderProducts.Commands.DeleteOrderProduct
{
    public class DeleteOrderProductQueryHandler : IRequestHandler<DeleteOrderProductQueryRequest, DeleteOrderProductQueryResponse>
    {
        readonly private IOrderProductWriteRepository _orderProductWriteRepository;

        public DeleteOrderProductQueryHandler(IOrderProductWriteRepository orderProductWriteRepository)
        {
            _orderProductWriteRepository = orderProductWriteRepository;
        }

        public async Task<DeleteOrderProductQueryResponse> Handle(DeleteOrderProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteResult = _orderProductWriteRepository.Delete(request.Id);
                var response = new DeleteOrderProductQueryResponse
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
