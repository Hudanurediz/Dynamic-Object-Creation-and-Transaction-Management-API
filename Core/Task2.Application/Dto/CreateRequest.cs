using Task2.Application.Features.Addresses.Commands.CreateAddress;
using Task2.Application.Features.Customers.Commands.CreateCustomer;
using Task2.Application.Features.OrderProducts.Commands.CreateOrderProduct;
using Task2.Application.Features.Orders.Commands.CreateOrder;
using Task2.Application.Features.Products.Commands.CreateProduct;

namespace Task2.Domain.Entities
{
    public class CreateRequest
    {
        //public CreateAddressQueryRequest? Address { get; set; }
        public CreateCustomerQueryRequest? Customer { get; set; }
        public CreateOrderProductQueryRequest? OrderProduct { get; set; }
        public CreateOrderQueryRequest? Order { get; set; }
        public CreateProductQueryRequest? Product { get; set; }
    }

}
