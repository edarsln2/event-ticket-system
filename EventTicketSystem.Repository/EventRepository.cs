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

    public void DeleteEvent(Event evnt)
    {
        _context.Events.Remove(evnt);
        _context.SaveChanges();
    }

    public Event? GetEventById(int id)
    {
        return _context.Events.FirstOrDefault(e => e.EventId == id);
    }

    public List<Event> GetEventList()
    {
        return _context.Events.Where(e => e.AvailableCapacity > 0 && e.StartDate <= DateTime.UtcNow && e.EndDate >= DateTime.UtcNow).ToList();
    }

    public void UpdateTicketSold(Event evnt)
    {
        _context.Events.Update(evnt);
        _context.SaveChanges();
    }
}
