using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Addresses.Queries.GetAllAddresses
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQueryRequest, GetAllAddressesQueryResponse>
    {
        readonly private IAddressReadRepository _addressReadRepository;

        public GetAllAddressesQueryHandler(IAddressReadRepository addressReadRepository)
        {
            _addressReadRepository = addressReadRepository;
        }

        public async Task<GetAllAddressesQueryResponse> Handle(GetAllAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var addresses = await _addressReadRepository.GetAllAsync();

                if (addresses == null || !addresses.Any())
                {
                    return new GetAllAddressesQueryResponse
                    {
                        Addresses = new List<Address>(),
                        Success = false,
                        Message = "Not found."
                    };
                }

                return new GetAllAddressesQueryResponse
                {
                    Addresses = addresses.ToList(),
                    Success = true,
                    Message = "Successful"
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
