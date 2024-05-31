namespace CreditCalculator.API.Extensions;

using Core;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services.CalculationHistory;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CreditCalculatorFactory>();
        services.AddScoped<ICalculationHistoryService, CalculationHistoryService>();
        services.AddScoped<ICreditCalculationHistoryRepository, CreditCalculationHistoryRepository>();

        services.AddDbContext<CreditCalculatorDbContext>(opt =>
        {
            opt.UseInMemoryDatabase("CreditCalculator");
            opt.LogTo(Console.WriteLine);
        });

        return services;
    }
}