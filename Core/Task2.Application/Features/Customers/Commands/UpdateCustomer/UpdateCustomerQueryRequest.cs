using MediatR;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerQueryRequest:IRequest<UpdateCustomerQueryResponse>
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public ICollection<Address>? Addresses { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public bool? IsNewAddress { get; set; }

        public bool? IsRemove { get; set; }
    }
}
