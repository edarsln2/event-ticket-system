using EventTicketSystem.Application;
using EventTicketSystem.Data;
using EventTicketSystem.Factory;
using EventTicketSystem.Repository;
using EventTicketSystem.Service;
using EventTicketSystem.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddScoped<InsertEventRequestValidator>();
builder.Services.AddScoped<RegisterUserRequestValidator>();
builder.Services.AddScoped<PurchaseTicketRequestValidator>();
builder.Services.AddScoped<EventApplication>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PurchaseService>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PurchaseRepository>();
builder.Services.AddScoped<EventFactory>();
builder.Services.AddScoped<UserFactory>();
builder.Services.AddScoped<PurchaseFactory>();

var app = builder.Build();

app.MapControllers();

app.Run();
