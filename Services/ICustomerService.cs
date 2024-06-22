using swag.Models;

namespace swag.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateOrUpdateCustomerAsync(Customer customer);

        Task<Customer?> GetByIdAsync(int id);

        Task<bool> EmailExistsAsync(string email); 

    }
}
