using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Application.Features.Addresses.Commands.UpdateAddress;

namespace Task2.Application.Features.OrderProducts.Commands.UpdateOrderProduct
{
    public class UpdateOrderProductQueryHandler : IRequestHandler<UpdateOrderProductQueryRequest, UpdateOrderProductQueryResponse>
    {
        readonly private IOrderProductWriteRepository _orderProductWriteRepository;
        readonly private IOrderProductReadRepository _orderProductReadRepository;

        public UpdateOrderProductQueryHandler(IOrderProductWriteRepository orderProductWriteRepository, IOrderProductReadRepository orderProductReadRepository)
        {
            _orderProductWriteRepository = orderProductWriteRepository;
            _orderProductReadRepository = orderProductReadRepository;
        }
        public async Task<UpdateOrderProductQueryResponse> Handle(UpdateOrderProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _orderProductReadRepository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateOrderProductQueryResponse
                    {
                        Success = false,
                        Message = "Entity not found."
                    };
                }

                if (request.ProductId.HasValue && request.ProductId != Guid.Empty)
                    entity.ProductId = request.ProductId.Value;


                if (request.Quantity.HasValue && request.Quantity > 0)
                    entity.Quantity = request.Quantity.Value;

                if (request.OrderId.HasValue && request.OrderId != Guid.Empty)
                    entity.OrderId = request.OrderId.Value;


                _orderProductWriteRepository.Update(request.Id, entity);
                await _orderProductWriteRepository.SaveAsync();
                return new UpdateOrderProductQueryResponse
                {
                    Success = true,
                    Message = "Entity updated successfully."
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
