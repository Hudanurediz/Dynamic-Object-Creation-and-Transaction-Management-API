using Microsoft.EntityFrameworkCore.Storage;
using Task2.Application.Abstractions;
using Task2.Application.Features.Customers.Commands.CreateCustomer;
using Task2.Domain.Entities;
using Task2.Persistance.Contexts;

namespace Task2.Persistance.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.BeginTransactionAsync();
        }


        public bool Delete(Guid customerId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var existingCustomer = Table.Find(customerId);
                if (existingCustomer == null)
                {
                    throw new ArgumentException("Customer does not exist.");
                }

                existingCustomer.DeletedDate = DateTime.UtcNow;

                var addresses = _context.Addresses.Where(a => a.CustomerId == customerId).ToList();
                foreach (var address in addresses)
                {
                    address.DeletedDate = DateTime.UtcNow;
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



        public async Task CreateCustomerWithTransactionAsync(CreateCustomerQueryRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var customer = new Customer
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };

                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();

                if (request.Addresses != null && request.Addresses.Any())
                {
                    foreach (var address in request.Addresses)
                    {
                        var newAddress = new Address(
                            address.Street,
                            address.City,
                            address.State,
                            address.PostalCode,
                            address.Country,
                            customer.Id
                        );

                        await _context.Addresses.AddAsync(newAddress);
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
