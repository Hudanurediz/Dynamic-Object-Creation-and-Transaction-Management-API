using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Addresses.Queries.GetByIdAddress
{
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQueryRequest, GetByIdAddressQueryResponse>
    {
        readonly private IAddressReadRepository _addressReadRepository;

        public GetByIdAddressQueryHandler(IAddressReadRepository addressReadRepository)
        {
            _addressReadRepository = addressReadRepository;
        }
        public async Task<GetByIdAddressQueryResponse> Handle(GetByIdAddressQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Address address = await _addressReadRepository.GetByIdAsync(request.Id);

                if (address == null)
                {
                    return new GetByIdAddressQueryResponse
                    {
                        Success = false,
                        Message = "Not found."
                    };

                }

                return new GetByIdAddressQueryResponse
                {
                    Address = address,
                    Success = true,
                    Message = "Succesfull"
                };
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
