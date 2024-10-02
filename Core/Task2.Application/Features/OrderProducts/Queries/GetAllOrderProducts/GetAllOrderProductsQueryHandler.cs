using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Application.Features.Addresses.Queries.GetAllAddresses;
using Task2.Domain.Entities;

namespace Task2.Application.Features.OrderProducts.Queries.GetAllOrderProducts
{
    public class GetAllOrderProductsQueryHandler : IRequestHandler<GetAllOrderProductsQueryRequest, GetAllOrderProductsQueryResponse>
    {
        readonly private IOrderProductReadRepository _orderProductReadRepository;

        public GetAllOrderProductsQueryHandler(IOrderProductReadRepository orderProductReadRepository)
        {
            _orderProductReadRepository = orderProductReadRepository;
        }
        public async Task<GetAllOrderProductsQueryResponse> Handle(GetAllOrderProductsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orderProducts = await _orderProductReadRepository.GetAllAsync();

                if (orderProducts == null || !orderProducts.Any())
                {
                    return new GetAllOrderProductsQueryResponse
                    {
                        OrderProducts = new List<OrderProduct>(),
                        Success = false,
                        Message = "Not found."
                    };
                }

                return new GetAllOrderProductsQueryResponse
                {
                    OrderProducts = orderProducts.ToList(),
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
