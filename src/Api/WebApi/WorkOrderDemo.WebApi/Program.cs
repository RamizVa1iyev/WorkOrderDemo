using WorkOrderDemo.Api.Application;
using WorkOrderDemo.Api.Infrastructure.Persistence;
using WorkOrderDemo.WebApi.Extensions;
using WorkOrderDemo.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationRegistration();
builder.Services.AddPersistenceRegistration(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorWebCors", builder =>
    {
        builder.WithOrigins("https://localhost:7156/")
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(opt => true);
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Configuration.MigrateAndSeed();

app.UseCors("BlazorWebCors");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
