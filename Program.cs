using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Services.Category;
using WebApiBurguerMania.Services.Oder;
using WebApiBurguerMania.Services.Product;
using WebApiBurguerMania.Services.Status;
using WebApiBurguerMania.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserInterface, UserService>();
builder.Services.AddScoped<StatusInterface, StatusService>();
builder.Services.AddScoped<ProductsInterface, ProductsService>();
builder.Services.AddScoped<OrderInterface, OrderService>();
builder.Services.AddScoped<CategoryInterface, CategoryService>();



// Adicionar o DbContext com PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicione o serviço CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Permitir esta origem específica
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();







// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure o middleware CORS
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
