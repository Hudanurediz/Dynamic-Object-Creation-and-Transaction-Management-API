using MediatR;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressQueryHandler : IRequestHandler<CreateAddressQueryRequest, CreateAddressQueryResponse>
    {
        readonly private IAddressWriteRepository _addressWriteRepository;
        public CreateAddressQueryHandler(IAddressWriteRepository addressWriteRepository)
        {
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<CreateAddressQueryResponse> Handle(CreateAddressQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var address = new Address(
                    request.Street,
                    request.City,
                    request.State,
                    request.PostalCode,
                    request.Country ,
                    request.CustomerId);

                var newAddress = await _addressWriteRepository.AddAsync(address);
                if (newAddress != null)
                {
                    return new CreateAddressQueryResponse
                    {
                        Address = newAddress,
                        Success = true,
                        Message = "Entity created successfully."
                    };
                }

                throw new InvalidOperationException("Failed to save the address entity.");
            }
            catch (DatabaseConnectionException dbEx)
            {
                throw new DatabaseConnectionException("Failed to update entity due to database connection issues.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating the address.", ex);
            }
        }


    }
}
