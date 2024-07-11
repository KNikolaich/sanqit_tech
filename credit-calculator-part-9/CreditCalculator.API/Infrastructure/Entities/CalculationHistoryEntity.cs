namespace CreditCalculator.API.Infrastructure.Entities;

using Core;

public class CalculationHistoryEntity
{
    public Guid Id { get; set; }
    public CalcType CalcType { get; set; }
    public virtual CalculationHistoryParametersEntity CalculationHistoryParameters { get; set; }
    public virtual CalculationHistoryResultEntity CalculationHistoryResult { get; set; }
    public DateTime CreatedOn { get; set; }
}