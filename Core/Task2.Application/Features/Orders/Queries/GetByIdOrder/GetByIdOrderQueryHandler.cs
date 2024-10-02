using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Orders.Queries.GetByIdOrder
{
    public class GetByIdOrderQueryHandler:IRequestHandler<GetByIdOrderQueryRequest,GetByIdOrderQueryResponse>
    {
        readonly private IOrderReadRepository _orderReadRepository;

        public GetByIdOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = await _orderReadRepository.GetByIdAsync(request.Id);

                if (order == null)
                {
                    return new GetByIdOrderQueryResponse
                    {
                        Success = false,
                        Message = "Not found."
                    };

                }

                return new GetByIdOrderQueryResponse
                {
                    Order = order,
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
