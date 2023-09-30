using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelEstates.Data.Abstraction.Helpers;
using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Helpers;
using TravelEstates.Data.Models.Entities.Base;
using TravelEstates.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TravelEstatesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddIdentity<User, Role>()
    .AddEntityFrameworkStores<TravelEstatesContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IRentPropertyRepository, RentPropertyRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITravelEstatesSignInManager, TravelEstateSingInManager>();
builder.Services.AddScoped<ITravelEstatesUserManager, TravelEstateUserManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
