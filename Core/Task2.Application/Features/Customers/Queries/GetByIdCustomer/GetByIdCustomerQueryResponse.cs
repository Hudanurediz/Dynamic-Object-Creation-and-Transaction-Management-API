using Task2.Domain.Entities;

namespace Task2.Application.Features.Customers.Queries.GetByIdCustomer
{
    public class GetByIdCustomerQueryResponse
    {
        public Customer Customer { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
