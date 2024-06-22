using swag.Data;
using swag.Models;
using Microsoft.EntityFrameworkCore;

namespace swag.Services
{
    public class customerService : ICustomerService
    {
        private readonly AnonUserDB _dbContext;

        public customerService(AnonUserDB dbContext)
        {
            _dbContext = dbContext;
        }


         public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _dbContext.customers.FindAsync(id); 
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbContext.customers.AnyAsync(c => c.email == email);
        }
       

        public async Task<Customer> CreateOrUpdateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _dbContext.customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
    }   }
}
