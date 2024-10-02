using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;

namespace Task2.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerQueryHandler : IRequestHandler<DeleteCustomerQueryRequest, DeleteCustomerQueryResponse>
    {
        readonly private ICustomerWriteRepository _customerWriteRepository;

        public DeleteCustomerQueryHandler(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<DeleteCustomerQueryResponse> Handle(DeleteCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteResult = _customerWriteRepository.Delete(request.Id);
                var response = new DeleteCustomerQueryResponse
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
