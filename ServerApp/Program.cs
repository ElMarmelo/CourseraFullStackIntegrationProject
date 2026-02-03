var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorCors", policy =>
    {
        policy.WithOrigins("http://localhost:5000")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddOutputCache();

var app = builder.Build();
app.UseCors("BlazorCors");
app.UseOutputCache();
app.MapGet("/api/products", () =>

{

    return new[]

    {

        new { Id = 1, Name = "Laptop", Price = 1200.50, Stock = 25, Category = new {Id = 1, Name = "Electronics"} },

        new { Id = 2, Name = "Headphones", Price = 50.00, Stock = 100, Category = new {Id = 2, Name = "Accesories"} }

    };

}).CacheOutput();

app.Run("http://localhost:5250");