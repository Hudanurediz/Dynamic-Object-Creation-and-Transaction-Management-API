using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Abstractions;
using Task2.Application.Exceptions;

namespace Task2.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductQueryHandler:IRequestHandler<UpdateProductQueryRequest,UpdateProductQueryResponse>
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public UpdateProductQueryHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<UpdateProductQueryResponse> Handle(UpdateProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _productReadRepository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateProductQueryResponse
                    {
                        Success = false,
                        Message = "Entity not found."
                    };
                }


                if (!string.IsNullOrEmpty(request.Name))
                    entity.Name = request.Name;


                if (!string.IsNullOrEmpty(request.Description))
                    entity.Description = request.Description;

                if (request.Price.HasValue && request.Price > 0)
                        entity.Price = request.Price.Value;

                if (!string.IsNullOrEmpty(request.Category))
                    entity.Category = request.Category;


                if (!string.IsNullOrEmpty(request.BarcodeCode))
                    entity.BarcodeCode = request.BarcodeCode;


                if (!string.IsNullOrEmpty(request.Brand))
                    entity.Brand = request.Brand;

                if (request.StockQuantity.HasValue && request.StockQuantity > 0)
                    entity.StockQuantity = request.StockQuantity.Value;

                _productWriteRepository.Update(request.Id, entity);
                await _productWriteRepository.SaveAsync();
                return new UpdateProductQueryResponse
                {
                    Success = true,
                    Message = "Entity updated successfully."
                };
            }
            catch (DbUpdateException dbEx)
            {
                throw new DatabaseConnectionException("Failed to update entity due to database connection issues.", dbEx);
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseConnectionException("Database connection error occurred.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}
