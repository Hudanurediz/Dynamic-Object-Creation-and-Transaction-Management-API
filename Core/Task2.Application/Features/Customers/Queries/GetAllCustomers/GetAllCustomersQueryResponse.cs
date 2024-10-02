using Task2.Domain.Entities;

namespace Task2.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryResponse
    {
        public List<Customer> Customers { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
