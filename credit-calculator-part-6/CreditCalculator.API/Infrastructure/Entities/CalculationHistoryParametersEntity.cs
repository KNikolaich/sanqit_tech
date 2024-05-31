namespace CreditCalculator.API.Infrastructure.Entities;

public class CalculationHistoryParametersEntity
{
    public Guid Id { get; set; }
    public double Credit { get; set; }
    public double Rate { get; set; }
    public int Period { get; set; }
    public Guid CalculationHistoryId { get; set; }
    public virtual CalculationHistoryEntity CalculationHistory { get; set; }
}