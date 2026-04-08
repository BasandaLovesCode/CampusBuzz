using Microsoft.EntityFrameworkCore;
using CampusBuzz_API.Data;
using CampusBuzz_API.Models;


namespace CampusBuzz_API.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetEventById(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<Event> AddEvent(Event campusEvent)
        {
            _context.Events.Add(campusEvent);
            await _context.SaveChangesAsync();
            return campusEvent;
        }

        public async Task<Event?> UpdateEvent(Event campusEvent)
        {
            var existing = await _context.Events.FindAsync(campusEvent.EventId);
            if (existing == null) return null;

            existing.EventTitle = campusEvent.EventTitle;
            existing.Location = campusEvent.Location;
            existing.TicketPrice = campusEvent.TicketPrice;

            await _context.SaveChangesAsync();
            return existing;
        }
       
        public async Task<bool> DeleteEvent(int id)
        {
            var campusEvent = await _context.Events.FindAsync(id);
            if (campusEvent == null) return false;

            _context.Events.Remove(campusEvent);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
