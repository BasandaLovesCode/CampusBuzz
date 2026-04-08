using CampusBuzz_API.Models;
using CampusBuzz_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CampusBuzz_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repository;

        public EventController(IEventRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            return Ok(await _repository.GetAllEvents());
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var campusEvent = await _repository.GetEventById(id);
            return campusEvent == null ? NotFound() : Ok(campusEvent);
        }

        // POST: api/Event
        [HttpPost]
        public async Task<ActionResult<Event>> AddEvent(Event campusEvent)
        {
            var newEvent = await _repository.AddEvent(campusEvent);
            return CreatedAtAction(nameof(GetEvent), new { id = newEvent.EventId }, newEvent);
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event campusEvent)
        {
            if (id != campusEvent.EventId) return BadRequest();
            var updatedEvent = await _repository.UpdateEvent(campusEvent);
            return updatedEvent == null ? NotFound() : NoContent();
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            return await _repository.DeleteEvent(id) ? NoContent() : NotFound();
        }
    }
}
