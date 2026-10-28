using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Use CORS
app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
// app.UseHttpsRedirection();

app.MapControllers();
app.Run();