using MediatR;

namespace Task2.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerQueryRequest:IRequest<DeleteCustomerQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
