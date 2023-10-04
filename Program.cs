using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Vehicle_Hub.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleHubConnectionString")));

builder.Services.AddCors(options => options.AddPolicy("default", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*app.UseRouting();*/

app.UseCors("default");

app.UseAuthorization();

app.MapControllers();

app.Run();
