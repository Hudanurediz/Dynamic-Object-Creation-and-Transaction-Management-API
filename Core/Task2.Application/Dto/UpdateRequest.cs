using Task2.Application.Features.Addresses.Commands.UpdateAddress;
using Task2.Application.Features.Customers.Commands.UpdateCustomer;
using Task2.Application.Features.OrderProducts.Commands.UpdateOrderProduct;
using Task2.Application.Features.Orders.Commands.UpdateOrder;
using Task2.Application.Features.Products.Commands.UpdateProduct;

namespace Task2.Application.Dto
{
    public class UpdateRequest
    {
        public UpdateAddressQueryRequest? Address {  get; set; }
        public UpdateCustomerQueryRequest? Customer { get; set; }
        public UpdateOrderProductQueryRequest? OrderProduct { get; set; }
        public UpdateOrderQueryRequest? Order { get; set; }
        public UpdateProductQueryRequest? Product { get; set; }
    }
}
