using Microsoft.EntityFrameworkCore;
using swag.Models;

namespace swag.Data

{
public class AnonUserDB : DbContext
{
    public AnonUserDB(DbContextOptions<AnonUserDB> options) : base (options) { }

    public DbSet<Customer> customers {get; set;}
    public DbSet<Event> events {get; set;}
    public DbSet<Ticket> tickets {get; set;}
    public DbSet<Venue> venues {get; set;}

    
}

}