using MediatR;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductQueryHandler : IRequestHandler<CreateProductQueryRequest, CreateProductQueryResponse>
    {
        readonly private IProductWriteRepository _productWriteRepository;

        public CreateProductQueryHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }
        public async Task<CreateProductQueryResponse> Handle(CreateProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Product(
                    request.Name,
                    request.Description,
                    request.Price,
                    request.Category,
                    request.BarcodeCode,
                    request.Brand,
                    request.StockQuantity,
                    request.OrderProducts);

                var newProduct = await _productWriteRepository.AddAsync(product);
                if (newProduct != null)
                {
                    return new CreateProductQueryResponse
                    {
                        Product = newProduct,
                        Success = true,
                        Message = "Entity created successfully."
                    };
                }

                throw new InvalidOperationException("Failed to save the address entity.");
            }
            catch (DatabaseConnectionException dbEx)
            {
                throw new DatabaseConnectionException("Failed to update entity due to database connection issues.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating the address.", ex);
            }
        }
    }
}
