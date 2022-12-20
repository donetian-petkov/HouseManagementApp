using PersonalManagementApp.Core.Contracts;
using PersonalManagementApp.Core.Services;
using PersonalManagementApp.Infrastructure.Data;
using PersonalManagementApp.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44480",
                                              "https://localhost:7244")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration["MySQLDatabase:ConnectionString"];

var serverVersion = new MySqlServerVersion(new Version(5, 7, 39));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString,serverVersion);
});
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITodoListService, TodoListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
