using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;

namespace Task2.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressQueryHandler : IRequestHandler<UpdateAddressQueryRequest, UpdateAddressQueryResponse>
    {
        readonly private IAddressWriteRepository _addressWriteRepository;
        readonly private IAddressReadRepository _addressReadRepository;

        public UpdateAddressQueryHandler(IAddressWriteRepository addressWriteRepository, IAddressReadRepository addressReadRepository)
        {
            _addressWriteRepository = addressWriteRepository;
            _addressReadRepository = addressReadRepository;
        }

        public async Task<UpdateAddressQueryResponse> Handle(UpdateAddressQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _addressReadRepository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateAddressQueryResponse
                    {
                        Success = false,
                        Message = "Entity not found."
                    };
                }

                if (!string.IsNullOrEmpty(request.Street))
                    entity.Street = request.Street;

                if (!string.IsNullOrEmpty(request.City))
                    entity.City = request.City;

                if (!string.IsNullOrEmpty(request.State))
                    entity.State = request.State;

                if (!string.IsNullOrEmpty(request.PostalCode))
                    entity.PostalCode = request.PostalCode;

                if (!string.IsNullOrEmpty(request.Country))
                    entity.Country = request.Country;


                _addressWriteRepository.Update(request.Id, entity);
                await _addressWriteRepository.SaveAsync();
                return new UpdateAddressQueryResponse
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
