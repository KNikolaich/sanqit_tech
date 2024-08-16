namespace CreditCalculator.API.Extensions;

using Configuration;
using Core;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services.CalculationHistory;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.Configure<ServiceOptions>(configuration.GetRequiredSection(nameof(ServiceOptions)));

        services.AddScoped<CreditCalculatorFactory>();
        services.AddScoped<ICalculationHistoryService, CalculationHistoryService>();
        services.AddScoped<ICreditCalculationHistoryRepository, CreditCalculationHistoryRepository>();

        services.AddDbContext<CreditCalculatorDbContext>(opt =>
        {
            opt
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention();
            //opt.UseInMemoryDatabase("CreditCalculator");
            opt.LogTo(Console.WriteLine);
        });

        return builder;
    }
}