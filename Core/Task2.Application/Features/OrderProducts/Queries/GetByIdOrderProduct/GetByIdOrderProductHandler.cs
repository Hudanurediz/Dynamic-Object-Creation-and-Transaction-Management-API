using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Domain.Entities;

namespace Task2.Application.Features.OrderProducts.Queries.GetByIdOrderProduct
{
    public class GetByIdOrderProductHandler : IRequestHandler<GetByIdOrderProductRequest, GetByIdOrderProductResponse>
    {
        readonly private IOrderProductReadRepository _orderProductReadRepository;

        public GetByIdOrderProductHandler(IOrderProductReadRepository orderProductReadRepository)
        {
            _orderProductReadRepository = orderProductReadRepository;
        }

        public async Task<GetByIdOrderProductResponse> Handle(GetByIdOrderProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                OrderProduct orderProduct = await _orderProductReadRepository.GetByIdAsync(request.Id);

                if (orderProduct == null)
                {
                    return new GetByIdOrderProductResponse
                    {
                        Success = false,
                        Message = "Not found."
                    };

                }

                return new GetByIdOrderProductResponse
                {
                    OrderProduct = orderProduct,
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
