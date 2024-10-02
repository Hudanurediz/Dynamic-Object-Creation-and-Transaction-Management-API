using MediatR;
using Task2.Application.Abstractions;
using Task2.Application.Features.Addresses.Queries.SearchAddress;

namespace Task2.Application.Features.Customers.Queries.SearchCustomer
{
    public class SearchCustomerQueryHandler:IRequestHandler<SearchCustomerQueryRequest,SearchCustomerQueryResponse>
    {
        readonly private ICustomerReadRepository _customerReadRepository;

        public SearchCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<SearchCustomerQueryResponse> Handle(SearchCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerReadRepository.SearchAsync(request.Property);

                Console.WriteLine(customer);

                return new SearchCustomerQueryResponse
                {
                    Customers = customer,
                    Success = true,
                    Message = "Customers retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
