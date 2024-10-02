using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;

namespace Task2.Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressQueryHandler : IRequestHandler<DeleteAddressQueryRequest, DeleteAddressQueryResponse>
    {
        readonly private IAddressWriteRepository _addressWriteRepository;

        public DeleteAddressQueryHandler(IAddressWriteRepository addressWriteRepository)
        {
            _addressWriteRepository = addressWriteRepository;
        }
        public async Task<DeleteAddressQueryResponse> Handle(DeleteAddressQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteResult = _addressWriteRepository.Delete(request.Id);
                var response = new DeleteAddressQueryResponse
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
