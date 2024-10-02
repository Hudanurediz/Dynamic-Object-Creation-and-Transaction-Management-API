using Task2.Application.Features.Addresses.Queries.SearchAddress;
using Task2.Application.Features.Customers.Queries.SearchCustomer;
using Task2.Application.Features.OrderProducts.Queries.SearchOrderProduct;
using Task2.Application.Features.Orders.Queries.SearchOrder;
using Task2.Application.Features.Products.Queries.SearchProduct;

namespace Task2.Application.Dto
{
    public class SearchRequest
    {
        public SearchAddressQueryRequest Addresses { get; set; }
        public SearchCustomerQueryRequest Customers { get; set; }
        public SearchOrderQueryRequest Orders { get; set; }
        public SearchOrderProductRequest OrderProducts { get; set; }
        public SearchProductQueryRequest Products { get; set; }
    }
}
