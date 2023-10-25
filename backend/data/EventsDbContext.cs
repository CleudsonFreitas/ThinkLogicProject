using Microsoft.EntityFrameworkCore;

public class EventsDbContext: DbContext
{
    public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options) {}

    public DbSet<EventEntity> Events => Set<EventEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost,1439;Initial Catalog=EventsDb;User Id=sa;Password=Whatever12!;");
        //optionsBuilder.UseSqlite(@"Data Source=c:\temp\eventsDb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedSomeEventData.Seed(modelBuilder);
    }
}
