using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task2.Application.Dto;
using Task2.Application.Features.Addresses.Commands.UpdateAddress;
using Task2.Application.Features.Addresses.Queries.GetAllAddresses;
using Task2.Application.Features.Addresses.Queries.GetByIdAddress;
using Task2.Application.Features.Addresses.Queries.SearchAddress;
using Task2.Application.Features.Customers.Queries.GetAllCustomers;
using Task2.Application.Features.Customers.Queries.GetByIdCustomer;
using Task2.Application.Features.Customers.Queries.SearchCustomer;
using Task2.Application.Features.OrderProducts.Queries.GetAllOrderProducts;
using Task2.Application.Features.OrderProducts.Queries.GetByIdOrderProduct;
using Task2.Application.Features.OrderProducts.Queries.SearchOrderProduct;
using Task2.Application.Features.Orders.Queries.GetAllOrders;
using Task2.Application.Features.Orders.Queries.GetByIdOrder;
using Task2.Application.Features.Orders.Queries.SearchOrder;
using Task2.Application.Features.Products.Queries.GetAllProducts;
using Task2.Application.Features.Products.Queries.GetByIdProduct;
using Task2.Application.Features.Products.Queries.SearchProduct;
using Task2.Domain.Entities;

namespace Task2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {

        readonly IMediator _mediator;

        public GeneralController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateRequest request)
        {
            var results = new List<object>();

            //if (request.Address != null)
            //{
            //    var addressResponse = await _mediator.Send(request.Address);
            //    results.Add(addressResponse);
            //}

            if (request.Customer != null)
            {
                var customerResponse = await _mediator.Send(request.Customer);
                results.Add(customerResponse);
            }

            if (request.OrderProduct != null)
            {
                var orderProductResponse = await _mediator.Send(request.OrderProduct);
                results.Add(orderProductResponse);
            }

            if (request.Order != null)
            {
                var orderResponse = await _mediator.Send(request.Order);
                results.Add(orderResponse);
            }

            if (request.Product != null)
            {
                var productResponse = await _mediator.Send(request.Product);
                results.Add(productResponse);
            }

            if (results.Count == 0)
            {
                return BadRequest("Data could not be created.");
            }

            return Ok(results);
        }

        [HttpGet]
        public async Task<IActionResult> GetEntities()
        {
            var results = new List<object>();

            var addressesResponse = await _mediator.Send(new GetAllAddressesQueryRequest());
            if (addressesResponse != null)
            {
                results.Add(addressesResponse);
            }

            var customersResponse = await _mediator.Send(new GetAllCustomersQueryRequest());
            if (customersResponse != null)
            {
                results.Add(customersResponse);
            }

            var orderProductsResponse = await _mediator.Send(new GetAllOrderProductsQueryRequest());
            if (orderProductsResponse != null)
            {
                results.Add(orderProductsResponse);
            }

            var ordersResponse = await _mediator.Send(new GetAllOrdersQueryRequest());
            if (ordersResponse != null)
            {
                results.Add(ordersResponse);
            }

            var productsResponse = await _mediator.Send(new GetAllProductsQueryRequest());
            if (productsResponse != null)
            {
                results.Add(productsResponse);
            }

            if (results.Count == 0)
            {
                return NotFound("Data not found.");
            }

            return Ok(results);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteRequest request)
        {
            var results = new List<object>();

            if (request.Address != null)
            {
                var addressResponse = _mediator.Send(request.Address);
                results.Add(addressResponse);
            }

            if (request.Customer != null)
            {
                var customerResponse = _mediator.Send(request.Customer);
                results.Add(customerResponse);
            }

            if (request.OrderProduct != null)
            {
                var orderProductResponse = _mediator.Send(request.OrderProduct);
                results.Add(orderProductResponse);
            }

            if (request.Order != null)
            {
                var orderResponse = _mediator.Send(request.Order);
                results.Add(orderResponse);
            }

            if (request.Product != null)
            {
                var productResponse = _mediator.Send(request.Product);
                results.Add(productResponse);
            }

            return Ok(results);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var results = new List<object>();

            var addressRequest = new GetByIdAddressQueryRequest { Id = id };
            var addressResponse = await _mediator.Send(addressRequest);
            if (addressResponse != null)
            {
                results.Add(addressResponse);
            }

            var customerRequest = new GetByIdCustomerQueryRequest { Id = id };
            var customerResponse = await _mediator.Send(customerRequest);
            if (customerResponse != null)
            {
                results.Add(customerResponse);
            }

            var orderProductRequest = new GetByIdOrderProductRequest { Id = id };
            var orderProductResponse = await _mediator.Send(orderProductRequest);
            if (orderProductResponse != null)
            {
                results.Add(orderProductResponse);
            }

            var orderRequest = new GetByIdOrderQueryRequest { Id = id };
            var orderResponse = await _mediator.Send(orderRequest);
            if (orderResponse != null)
            {
                results.Add(orderResponse);
            }

            var productRequest = new GetByIdProductQueryRequest { Id = id };
            var productResponse = await _mediator.Send(productRequest);
            if (productResponse != null)
            {
                results.Add(productResponse);
            }

            if (results.Count == 0)
            {
                return BadRequest("No data found.");
            }

            return Ok(results);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRequest request)
        {
            var results = new List<object>();

            if (request.Address != null)
            {
                var addressResponse = await _mediator.Send(request.Address);
                results.Add(addressResponse);
            }

            if (request.Customer != null)
            {
                var customerResponse = await _mediator.Send(request.Customer);
                results.Add(customerResponse);
            }

            if (request.OrderProduct != null)
            {
                var orderProductResponse = await _mediator.Send(request.OrderProduct);
                results.Add(orderProductResponse);
            }

            if (request.Order != null)
            {
                var orderResponse = await _mediator.Send(request.Order);
                results.Add(orderResponse);
            }

            if (request.Product != null)
            {
                var productResponse = await _mediator.Send(request.Product);
                results.Add(productResponse);
            }

            return Ok(results);
        }


        [HttpGet("search")]
        public async Task<ActionResult<SearchAddressQueryResponse>> SearchAddresses([FromQuery] string property)
        {
            var results = new List<object>();

            var addressRequest = new SearchAddressQueryRequest { Property = property };
            var addressResponse = await _mediator.Send(addressRequest);
            if (addressResponse != null)
            {
                results.Add(addressResponse);
            }

            var customerRequest = new SearchCustomerQueryRequest { Property = property };
            var customerResponse = await _mediator.Send(customerRequest);
            if (customerResponse != null)
            {
                results.Add(customerResponse);
            }

            var orderProductRequest = new SearchOrderProductRequest { Property = property };
            var orderProductResponse = await _mediator.Send(orderProductRequest);
            if (orderProductResponse != null)
            {
                results.Add(orderProductResponse);
            }

            var orderRequest = new SearchOrderQueryRequest { Property = property };
            var orderResponse = await _mediator.Send(orderRequest);
            if (orderResponse != null)
            {
                results.Add(orderResponse);
            }

            var productRequest = new SearchProductQueryRequest { Property = property };
            var productResponse = await _mediator.Send(productRequest);
            if (productResponse != null)
            {
                results.Add(productResponse);
            }

            if (results.Count == 0)
            {
                return BadRequest("No data found.");
            }

            return Ok(results);
        }

        [HttpGet("type")]
        public async Task<IActionResult> GetEntities(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return BadRequest("Type parameter is required.");
            }

            object response = null;

            switch (type.ToLower())
            {
                case "address":
                    response = await _mediator.Send(new GetAllAddressesQueryRequest());
                    break;
                case "customer":
                    response = await _mediator.Send(new GetAllCustomersQueryRequest());
                    break;
                case "orderproduct":
                    response = await _mediator.Send(new GetAllOrderProductsQueryRequest());
                    break;
                case "order":
                    response = await _mediator.Send(new GetAllOrdersQueryRequest());
                    break;
                case "product":
                    response = await _mediator.Send(new GetAllProductsQueryRequest());
                    break;
                default:
                    return NotFound("Incorrect data type");
            }

            if (response == null)
            {
                return NotFound("Data not found.");
            }

            return Ok(response);
        }

    }
}
