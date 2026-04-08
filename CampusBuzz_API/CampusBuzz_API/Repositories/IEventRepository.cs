using CampusBuzz_API.Models;

namespace CampusBuzz_API.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event?> GetEventById(int id);
        Task<Event> AddEvent(Event campusEvent);
        Task<Event?> UpdateEvent(Event campusEvent);
        Task<bool> DeleteEvent(int id);
    }
}
