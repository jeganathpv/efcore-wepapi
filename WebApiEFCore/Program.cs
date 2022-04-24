using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApiEFCore.Context;
using WebApiEFCore.Prerequisite;
using WebApiEFCore.Repository;
using WebApiEFCore.Services;

var builder = WebApplication.CreateBuilder(args);


IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = configuration.GetConnectionString("MySQLConn");

// DI to seed data
builder.Services.AddTransient<DataSeeder>();

builder.Services.AddDbContext<CompanyContext>(options =>
    options.UseMySql(connectionString: connString, serverVersion: ServerVersion.AutoDetect(connString))
);


// DI for services, repos
builder.Services.AddTransient<EmployeeRepository>();
builder.Services.AddTransient<EmployeeService>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<UserService>();

var app = builder.Build();

// To run data seeder
SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using(var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}