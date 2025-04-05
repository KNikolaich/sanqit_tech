namespace CreditCalculator.API.Infrastructure.Entities;

public class CalculationHistoryResultEntity
{
    public Guid Id { get; set; }
    public double? Payment { get; set; }
    public double SumPayment { get; set; }
    public double SumMainDebtPayment { get; set; }
    public double SumPercentPayment { get; set; }
    public double MainDebtInPercent { get; set; }
    public double PercentsInPercent { get; set; }
    public Guid CalculationHistoryId { get; set; }
    public virtual CalculationHistoryEntity CalculationHistory { get; set; }
    public virtual ICollection<CalculationHistoryPaymentInfoEntity> CalculationHistoryPaymentInfos { get; set; }
}