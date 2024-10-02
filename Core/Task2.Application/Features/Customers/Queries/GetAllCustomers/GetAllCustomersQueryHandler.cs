using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, GetAllCustomersQueryResponse>
    {
        readonly private ICustomerReadRepository _customerReadRepository;

        public GetAllCustomersQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }
        public async Task<GetAllCustomersQueryResponse> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _customerReadRepository.GetAllAsync();

                if (customers == null || !customers.Any())
                {
                    return new GetAllCustomersQueryResponse
                    {
                        Customers = new List<Customer>(),
                        Success = false,
                        Message = "Not found."
                    };
                }

                return new GetAllCustomersQueryResponse
                {
                    Customers = customers.ToList(),
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
