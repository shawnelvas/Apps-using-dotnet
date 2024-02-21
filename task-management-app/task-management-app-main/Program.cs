global using TaskManagementApp.Dtos;
global using TaskManagementApp.Models;
global using TaskManagementApp.Services;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using TaskManagementApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ITaskService, TaskService>();



// builder.Services.AddScoped(<ITaskService>,<TaskService>);
// builder.Services.AddScoped();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope =
app.Services
.CreateScope()) { var services = scope.ServiceProvider; var dbContext = services.GetRequiredService<DataContext>(); dbContext.Database.Migrate(); }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
