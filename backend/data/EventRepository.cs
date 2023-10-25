using Microsoft.EntityFrameworkCore;

public interface IEventRepository
{
    Task<List<EventDto>> GetAll();
    Task<EventDetailDto?> Get(int id);
    Task<EventDetailDto> Add(EventDetailDto _event);
    Task<EventDetailDto> Update(EventDetailDto _event);
}

public class EventRepository : IEventRepository
{
    private readonly EventsDbContext context;

    private static EventDetailDto EntityToDetailDto(EventEntity e)
    {
        return new EventDetailDto(e.Id, e.Title, e.Location, e.Description, e.StartDate, e.EndDate);
    }

    private static void DtoToEntity(EventDetailDto dto, EventEntity e)
    {
        e.Location = dto.Location;
        e.Title = dto.Title;
        e.Description = dto.Description;
        e.StartDate = dto.StartDate;
        e.EndDate = dto.EndDate;
    }

    public EventRepository(EventsDbContext context)
    {
        this.context = context;
    }

    public async Task<List<EventDto>> GetAll()
    {
        return await context.Events.Select(e => new EventDto(e.Id, e.Title, e.StartDate, e.EndDate)).ToListAsync();
    }

    public async Task<EventDetailDto?> Get(int id)
    {
        var entity = await context.Events.SingleOrDefaultAsync(h => h.Id == id);
        if (entity == null)
            return null;
        return EntityToDetailDto(entity);
    }

    public async Task<EventDetailDto> Add(EventDetailDto dto)
    {
        var entity = new EventEntity();
        DtoToEntity(dto, entity);
        context.Events.Add(entity);
        await context.SaveChangesAsync();
        return EntityToDetailDto(entity);
    }

    public async Task<EventDetailDto> Update(EventDetailDto dto)
    {
        var entity = await context.Events.FindAsync(dto.Id);
        if (entity == null)
            throw new ArgumentException($"Trying to update event: entity with ID {dto.Id} not found.");
        DtoToEntity(dto, entity);
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return EntityToDetailDto(entity);
    }
}