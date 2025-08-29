using Booking.Service.Domain.Home;
using Booking.Service.Infrastructure;
using Booking.Service.Repository.Data;
using Booking.Service.WebApi.Configuration;
using Booking.Service.WebApi.Exceptions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
	var builder = WebApplication.CreateBuilder(args);

	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	builder.Services.InjectServices();

    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    builder.Services.AddAutoMapper(typeof(MappingProfile));
	builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Booking"));

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();

    var app = builder.Build();

    // Adding dummy data
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (!context.Homes.Any())
        {
            var homes = new List<Home>();

            for (int i = 1; i <= 10; i++)
            {
                var slots = new HashSet<DateTime>();
                for (int d = 0; d < 5; d++)
                    slots.Add(DateTime.Today.AddDays(i + d));

                homes.Add(new Home
                {
                    HomeId = Guid.NewGuid(),
                    HomeName = $"Home {i}",
                    AvailableSlots = slots
                });
            }

            context.Homes.AddRange(homes);
            context.SaveChanges();
        }
    }

    if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

    app.UseExceptionHandler();

    app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch (Exception ex)
{
	Log.Fatal(ex, "Application was crashed");
}

public partial class Program { }