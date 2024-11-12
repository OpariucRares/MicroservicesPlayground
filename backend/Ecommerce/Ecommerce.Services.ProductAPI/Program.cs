
using Ecommerce.Services.ProductAPI.Data;
using Ecommerce.Services.ProductAPI.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Services.ProductAPI.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//database
builder.Services.AddScoped<IProductDbContext, ProductDbContext>();
builder.Services.AddScoped<IProductMapper, ProductMapper>();
builder.Services.AddDbContext<ProductDbContext>();

//repositories
builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

ApplyMigration();

app.Run();

return;

void ApplyMigration()
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();

    //if there are pending migrations, it will apply them
    //if not, it will ignore
    if (db.Database.GetPendingMigrations().Any())
    {
        db.Database.Migrate();
    }
}
