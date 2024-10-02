using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;

namespace Task2.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderQueryHandler:IRequestHandler<DeleteOrderQueryRequest,DeleteOrderQueryResponse>
    {
        readonly private IOrderWriteRepository _orderWriteRepository;

        public DeleteOrderQueryHandler(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<DeleteOrderQueryResponse> Handle(DeleteOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteResult = _orderWriteRepository.Delete(request.Id);
                var response = new DeleteOrderQueryResponse
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
