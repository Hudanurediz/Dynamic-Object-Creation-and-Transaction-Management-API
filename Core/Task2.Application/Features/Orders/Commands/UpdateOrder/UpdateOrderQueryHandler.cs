using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Application.Features.Customers.Commands.UpdateCustomer;

namespace Task2.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderQueryHandler : IRequestHandler<UpdateOrderQueryRequest, UpdateOrderQueryResponse>
    {
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        public UpdateOrderQueryHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        public async Task<UpdateOrderQueryResponse> Handle(UpdateOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _orderReadRepository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateOrderQueryResponse
                    {
                        Success = false,
                        Message = "Entity not found."
                    };
                }

                if (request.CustomerId.HasValue && request.CustomerId != Guid.Empty)
                    entity.CustomerId = request.CustomerId.Value;

                if (!string.IsNullOrEmpty(request.Status))
                    entity.Status = request.Status;

                if (!string.IsNullOrEmpty(request.TrackingNumber))
                    entity.TrackingNumber = request.TrackingNumber;


                _orderWriteRepository.Update(request.Id, entity);
                await _orderWriteRepository.SaveAsync();
                return new UpdateOrderQueryResponse
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
