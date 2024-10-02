using MediatR;

namespace Task2.Application.Features.Customers.Queries.GetByIdCustomer
{
    public class GetByIdCustomerQueryRequest:IRequest<GetByIdCustomerQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
