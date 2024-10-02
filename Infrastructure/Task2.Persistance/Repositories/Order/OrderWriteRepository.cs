using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Task2.Application.Abstractions;
using Task2.Application.Features.Orders.Commands.CreateOrder;
using Task2.Domain.Entities;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.BeginTransactionAsync();
        }

        public bool Delete(Guid id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var existingOrder = Table.Find(id);
                if (existingOrder == null)
                {
                    throw new ArgumentException("Order does not exist.");
                }

                existingOrder.DeletedDate = DateTime.UtcNow;

                var orderProducts = _context.OrderProducts.Where(op => op.OrderId == id).ToList();

                foreach (var orderProduct in orderProducts)
                {
                    orderProduct.DeletedDate = DateTime.UtcNow;
                }

                _context.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Exception: {ex.Message}");
                transaction.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }
        }



        public async Task CreateOrderWithTransactionAsync(CreateOrderQueryRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var order = new Order
                {
                    CustomerId = request.CustomerId,
                    Status = request.Status,
                    TrackingNumber = request.TrackingNumber
                };

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                if (order.Id == Guid.Empty)
                {
                    throw new Exception("Order was not created successfully.");
                }

                if (request.OrderProducts != null && request.OrderProducts.Any())
                {
                    foreach (var orderProduct in request.OrderProducts)
                    {
                        if (orderProduct.Quantity <= 0)
                        {
                            throw new Exception($"Quantity for Product ID {orderProduct.ProductId} must be greater than zero.");
                        }

                        var newOrderProduct = new OrderProduct
                        {
                            ProductId = orderProduct.ProductId,
                            OrderId = order.Id,
                            Quantity = orderProduct.Quantity
                        };

                        await _context.OrderProducts.AddAsync(newOrderProduct);
                    }

                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }



    }
}
