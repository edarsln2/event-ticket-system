using EventTicketSystem.Data;
using EventTicketSystem.Entity;

public class EventRepository
{
    private readonly AppDbContext _context;

    public EventRepository(AppDbContext context)
    {
        _context = context;
    }

    public Event InsertEvent(Event evnt)
    {
        _context.Events.Add(evnt);
        _context.SaveChanges();
        return evnt;
    }

    public void DeleteEvent(int eventId)
    {
        var evnt = _context.Events.Find(eventId);

        if (evnt != null)
        {
            _context.Events.Remove(evnt);
            _context.SaveChanges();
        }
    }

    public Event? GetEventById(int id)
    {
        return _context.Events.FirstOrDefault(e => e.EventId == id);
    }


    public List<Event> GetEventList()
    {
        return _context.Events.ToList();
    }

    public void UpdateCapacity(Event evnt)
    {
        _context.Events.Update(evnt);
        _context.SaveChanges(); 
    }
}
