using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;

namespace Task2.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerQueryHandler : IRequestHandler<UpdateCustomerQueryRequest, UpdateCustomerQueryResponse>
    {
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;

        public UpdateCustomerQueryHandler(ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
        }
        public async Task<UpdateCustomerQueryResponse> Handle(UpdateCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _customerReadRepository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateCustomerQueryResponse
                    {
                        Success = false,
                        Message = "Entity not found."
                    };
                }

                if (!string.IsNullOrEmpty(request.FirstName))
                    entity.FirstName = request.FirstName;

                if (!string.IsNullOrEmpty(request.LastName))
                    entity.LastName = request.LastName;

                if (!string.IsNullOrEmpty(request.UserName))
                    entity.UserName = request.UserName;

                if (!string.IsNullOrEmpty(request.Email))
                    entity.Email = request.Email;

                if (!string.IsNullOrEmpty(request.PhoneNumber))
                    entity.PhoneNumber = request.PhoneNumber;

                //orderlara bak

                _customerWriteRepository.Update(request.Id, entity);
                await _customerWriteRepository.SaveAsync();
                return new UpdateCustomerQueryResponse
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
