namespace CreditCalculator.API.Infrastructure;

using Entities;
using Microsoft.EntityFrameworkCore;

public class CreditCalculatorDbContext : DbContext
{
    public CreditCalculatorDbContext(
        DbContextOptions<CreditCalculatorDbContext> options
    ) : base(options)
    {
    }

    public DbSet<CalculationHistoryEntity> CalculationHistory => Set<CalculationHistoryEntity>();
    public DbSet<CalculationHistoryParametersEntity> CalculationHistoryParameters => Set<CalculationHistoryParametersEntity>();
    public DbSet<CalculationHistoryResultEntity> CalculationHistoryResults => Set<CalculationHistoryResultEntity>();
    public DbSet<CalculationHistoryPaymentInfoEntity> CalculationHistoryPaymentInfos => Set<CalculationHistoryPaymentInfoEntity>();
}