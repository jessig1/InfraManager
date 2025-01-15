using InfraManager.Data;
using InfraManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ServiceContext>(options =>
    options.UseInMemoryDatabase("Services"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var serviceItems = app.MapGroup("/newservice");

serviceItems.MapGet("/", async (ServiceContext db) =>
    await db.Services.ToListAsync());

serviceItems.MapGet("/{id}", async (ServiceContext db, int id) =>
    await db.Services.FindAsync(id));

serviceItems.MapPost("/", async (Service service, ServiceContext db) =>
{     db.Services.Add(service);
    await db.SaveChangesAsync();
    return Results.Created($"/newservice/{service.Id}", service);
});

serviceItems.MapPut("/{id}", async (Service service, ServiceContext db, int id) =>
{
    if (id != service.Id)
    {
        return Results.BadRequest();
    }

    db.Entry(service).State = EntityState.Modified;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

serviceItems.MapDelete("/{id}", async (ServiceContext db, int id) =>
{
    var service = await db.Services.FindAsync(id);
    if (service == null)
    {
        return Results.NotFound();
    }

    db.Services.Remove(service);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
