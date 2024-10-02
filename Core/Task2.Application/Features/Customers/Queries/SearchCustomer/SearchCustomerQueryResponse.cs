using Task2.Domain.Entities;

namespace Task2.Application.Features.Customers.Queries.SearchCustomer
{
    public class SearchCustomerQueryResponse
    {
        public List<Customer> Customers { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
