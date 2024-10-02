using Task2.Application.Features.Addresses.Commands.DeleteAddress;
using Task2.Application.Features.Customers.Commands.DeleteCustomer;
using Task2.Application.Features.OrderProducts.Commands.DeleteOrderProduct;
using Task2.Application.Features.Orders.Commands.DeleteOrder;
using Task2.Application.Features.Products.Commands.DeleteProduct;

namespace Task2.Application.Dto
{
    public class DeleteRequest
    {
        public DeleteAddressQueryRequest? Address { get; set; }
        public DeleteCustomerQueryRequest? Customer { get; set; }
        public DeleteOrderProductQueryRequest? OrderProduct { get; set; }
        public DeleteOrderQueryRequest? Order { get; set; }
        public DeleteProductQueryRequest? Product { get; set; }
    }
}
