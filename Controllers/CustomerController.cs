using swag.Models;
using swag.Data;
using swag.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace swag.Controllers{

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly AnonUserDB _dbContext;
    private readonly ICustomerService _customerService; 

    public CustomerController(AnonUserDB dbContext, ICustomerService customerService)
    {
        _dbContext = dbContext;
        _customerService = customerService; // Inject the customer service
    }


    [HttpGet("check-email")] // New endpoint to check email existence
    public async Task<IActionResult> CheckEmailExists([FromQuery] string email)
    {
        var exists = await _customerService.EmailExistsAsync(email);
        return Ok(new { exists }); // Return a JSON response indicating if the email exists
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOrUpdateCustomer([FromBody] CustomerCreation request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var newCustomer = new Customer 
            {
                email = request.email,
                instagram = request.instagram,
            };

            _dbContext.customers.Add(newCustomer);
            await _dbContext.SaveChangesAsync(); // Save to generate the CustomerId

            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.customer_id }, newCustomer);
        }
        catch (DbUpdateException ex)
        {
            // Log the exception (ex.Message) for debugging
            return StatusCode(500, "An error occurred while saving the customer.");
        }
    }

    [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _dbContext.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
}

}
