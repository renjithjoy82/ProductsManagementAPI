using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Data;
using ProductsManagementAPI.Repository;

var myAllowedSpecificOrigins = "_myAllowedSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsManagementConnection"));
});
// Inject Dependency of UnitOFWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowedSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowedSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
