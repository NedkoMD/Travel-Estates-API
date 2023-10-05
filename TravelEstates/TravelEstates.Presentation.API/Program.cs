using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TravelEstates.Business.Abstraction.Factories;
using TravelEstates.Business.Abstraction.Services;
using TravelEstates.Business.Factories;
using TravelEstates.Business.Profiles;
using TravelEstates.Business.Services;
using TravelEstates.Data.Abstraction.Helpers;
using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Helpers;
using TravelEstates.Data.Models.Entities.Base;
using TravelEstates.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

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
builder.Services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITravelEstatesSignInManager, TravelEstateSingInManager>();
builder.Services.AddScoped<ITravelEstatesUserManager, TravelEstateUserManager>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IRentPropertyService, RentPropertyService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IResultFactory, ResultFactory>();
builder.Services.AddAutoMapper(typeof(TravelEstatesProfile));

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
