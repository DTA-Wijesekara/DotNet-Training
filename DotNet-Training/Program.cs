using DotNet_Training.Context;
using DotNet_Training.Mappings;
using DotNet_Training.Repositories;
using DotNet_Training.Repositories.DifficultyServices;
using DotNet_Training.Repositories.WalkServices;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/Training_Log.txt", rollingInterval: RollingInterval.Minute )
    .MinimumLevel.Information()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger); 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<dasunDbcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbstring")));

//ape service folder eka nathnam Repository folder eka gana kiyala = dependency injection
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();
//builder.Services.AddScoped<IDifficultyRepository, SQLDifficultyRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
