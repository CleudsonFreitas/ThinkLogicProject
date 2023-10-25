using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<EventsDbContext>(options => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddScoped<IEventRepository, EventRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(a => a.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

//app.UseHttpsRedirection();

app.MapGet("/events", (IEventRepository repo) => repo.GetAll())
            .Produces<EventDto[]>(StatusCodes.Status200OK);

app.MapGet("/event/{eventId:int}", async (int eventId, IEventRepository repo) => 
        {
            var _event = await repo.Get(eventId);
            if (_event == null)
                return Results.Problem($"Event with ID {eventId} not found.", statusCode: 404);
            return Results.Ok(_event);
        }).ProducesProblem(404).Produces<EventDetailDto>(StatusCodes.Status200OK);
    
app.MapPost("/events", async ([FromBody] EventDetailDto dto, IEventRepository repo) => 
        {
            if (!MiniValidator.TryValidate(dto, out var errors))
                return Results.ValidationProblem(errors);
            var newEvent = await repo.Add(dto);
            return Results.Created($"/event/{newEvent.Id}", newEvent);
        }).ProducesValidationProblem().Produces<EventDetailDto>(StatusCodes.Status201Created);

app.MapPut("/events", async ([FromBody] EventDetailDto dto, IEventRepository repo) => 
{       
    if (!MiniValidator.TryValidate(dto, out var errors))
        return Results.ValidationProblem(errors);
    if (await repo.Get(dto.Id) == null)
        return Results.Problem($"Event with Id {dto.Id} not found", statusCode: 404);
    var updatedEvent = await repo.Update(dto);
    return Results.Ok(updatedEvent);
}).ProducesValidationProblem().ProducesProblem(404).Produces<EventDetailDto>(StatusCodes.Status200OK);

app.Run();
