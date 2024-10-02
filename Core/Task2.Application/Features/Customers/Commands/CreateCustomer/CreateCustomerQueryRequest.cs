using MediatR;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerQueryRequest : IRequest<CreateCustomerQueryResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Address>? Addresses { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}

