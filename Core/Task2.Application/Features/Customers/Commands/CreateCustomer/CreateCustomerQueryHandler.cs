using MediatR;
using Task2.Application.Abstractions;

namespace Task2.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerQueryHandler : IRequestHandler<CreateCustomerQueryRequest, CreateCustomerQueryResponse>
    {
        readonly private ICustomerWriteRepository _customerWriteRepository;

        public CreateCustomerQueryHandler(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<CreateCustomerQueryResponse> Handle(CreateCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _customerWriteRepository.CreateCustomerWithTransactionAsync(request);
                return new CreateCustomerQueryResponse
                {
                    Success = true,
                    Message = "Customer created successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateCustomerQueryResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
