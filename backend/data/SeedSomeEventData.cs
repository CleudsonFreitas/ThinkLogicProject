using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

public static class SeedSomeEventData
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<EventEntity>().HasData(new List<EventEntity> {
            new EventEntity {
                Id = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Description = "Sync up new feature meeting...",
                Location = "Florida",
                Title = "SyncUp Meeting"
            },
            new EventEntity {
                Id = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Description = "Follow-up Dentist...",
                Location = "San Francisco",
                Title = "Dentist appointmentt"
            },
            new EventEntity {
                Id = 3,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                Description = "Daily Meeting on green room...",
                Location = "Michigan",
                Title = "Daily Metting"
            },
            new EventEntity {
                Id = 4,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(4),
                Description = "Meeting with friends...",
                Location = "San Francisco",
                Title = "Friends Meeting"
            }
        });            
    }
}
