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



app.MapGet("/newservice", async (ServiceContext db) =>
    await db.Services.ToListAsync());

app.MapGet("/newservice/{id}", async (ServiceContext db, int id) =>
    await db.Services.FindAsync(id));

app.MapPost("/newservice", async (Service service, ServiceContext db) =>
{     db.Services.Add(service);
    await db.SaveChangesAsync();
    return Results.Created($"/newservice/{service.Id}", service);
});



app.Run();
