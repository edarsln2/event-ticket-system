using EventTicketSystem.Data;
using EventTicketSystem.Factory;
using EventTicketSystem.Repository;
using EventTicketSystem.Service;
using EventTicketSystem.Validation.DiscountValidation;
using EventTicketSystem.Validation.PurchaseValidation;
using EventTicketSystem.WebApi.ApplicationStorage;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var issur = builder.Configuration["JwtConfig:Issuer"];
var audience = builder.Configuration["JwtConfig:Audience"];
var signingKey = builder.Configuration["JwtConfig:SigningKey"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = ClaimTypes.NameIdentifier,
        RoleClaimType = ClaimTypes.Role,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issur,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddScoped<InsertEventRequestValidator>();
builder.Services.AddScoped<DeleteEventRequestValidator>();
builder.Services.AddScoped<GetEventByIdRequestValidator>();
builder.Services.AddScoped<RegisterUserRequestValidator>();
builder.Services.AddScoped<LoginRequestValidator>();
builder.Services.AddScoped<PurchaseTicketWithLoginRequestValidator>();
builder.Services.AddScoped<PurchaseTicketAsGuestRequestValidator>();
builder.Services.AddScoped<InsertDiscountRequestValidator>();
builder.Services.AddScoped<DeleteDiscountRequestValidator>();

builder.Services.AddScoped<EventApplication>();
builder.Services.AddScoped<UserApplication>();
builder.Services.AddScoped<PurchaseApplication>();
builder.Services.AddScoped<DiscountApplication>();
builder.Services.AddScoped<ApplicationStorage>();

builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PurchaseService>();
builder.Services.AddScoped<DiscountService>();
builder.Services.AddScoped<JwtTokenGeneratorService>();
builder.Services.AddScoped<EmailSenderService>();

builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PurchaseRepository>();
builder.Services.AddScoped<DiscountRepository>();

builder.Services.AddScoped<EventFactory>();
builder.Services.AddScoped<UserFactory>();
builder.Services.AddScoped<PurchaseFactory>();
builder.Services.AddScoped<DiscountFactory>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
