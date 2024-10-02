using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
    {
        readonly private IOrderReadRepository _orderReadRepository;

        public GetAllOrdersQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _orderReadRepository.GetAllAsync();

                if (orders == null || !orders.Any())
                {
                    return new GetAllOrdersQueryResponse
                    {
                        Orders = new List<Order>(),
                        Success = false,
                        Message = "Not found."
                    };
                }

                return new GetAllOrdersQueryResponse
                {
                    Orders = orders.ToList(),
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
