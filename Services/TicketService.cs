using swag.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using swag.Data;
using Microsoft.EntityFrameworkCore;

namespace swag.Services
{
    public class TicketService : ITicketService
    {
        private readonly AnonUserDB _context;

        public TicketService(AnonUserDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _context.tickets.ToListAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _context.tickets.FindAsync(id);
        }

        public async Task<Ticket> AddTicketAsync(Ticket ticket)
        {
            _context.tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateTicketAsync(Ticket ticket)
        {
            _context.tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> DeleteTicketAsync(int id)
        {
            var ticket = await _context.tickets.FindAsync(id);
            if (ticket == null)
            {
                return false;
            }

            _context.tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
