using EComServices.Models;
using EComServices.Repository.@interface;
using EComServices.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<AdbContextConfiguration>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("EComAPI")));
builder.Services.AddScoped<IUserRegistration, ServiceImplementation>();
builder.Services.AddScoped<ICountryList, ServiceImplementation>();
//builder.Services.AddScoped<IStateList, ServiceImplementation>();
builder.Services.AddScoped<ILogin, ServiceImplementation>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EComAPI", Version = "v1" });
});
builder.Services.AddCors(c =>
c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
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
