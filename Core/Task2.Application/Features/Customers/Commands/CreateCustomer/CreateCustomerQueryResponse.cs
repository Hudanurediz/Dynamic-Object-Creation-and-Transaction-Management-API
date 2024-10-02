using Task2.Domain.Entities;

namespace Task2.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerQueryResponse
    {
        public Customer? Customer { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
