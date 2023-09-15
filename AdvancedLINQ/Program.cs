using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Core.UnitofWork;
using AdvancedLINQ.Data.Context;
using AdvancedLINQ.Data.Repositories;
using AdvancedLINQ.Data.Seeds;
using AdvancedLINQ.Data.UnitofWork;
using AdvancedLINQ.Service.CQRS.Queries.SearchMedias;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
})
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssemblyContaining<Program>();
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AdvancedLINQDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"), dbOptions =>
    {
        dbOptions.MigrationsAssembly("AdvancedLINQ.Data");
    });
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(SearchMediasQuery).Assembly);
});

builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryMediaRepository, CategoryMediaRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IJobTaskRepository, JobTaskRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<AdvancedLINQDbContext>();
        await CategorySeeds.AddSeedCategories(dbContext);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "DbContext baþlatma hatasý");
    }
}

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
