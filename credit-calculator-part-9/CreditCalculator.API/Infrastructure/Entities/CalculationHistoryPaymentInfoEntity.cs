namespace CreditCalculator.API.Infrastructure.Entities;

public class CalculationHistoryPaymentInfoEntity
{
    public Guid Id { get; set; }
    public int PaymentNumber { get; set; }
    public double Payment { get; set; }
    public double MainDebtPayment { get; set; }
    public double PercentPayment { get; set; }
    public double Debt { get; set; }
    public Guid CalculationHistoryResultId { get; set; }
    public virtual CalculationHistoryResultEntity CalculationHistoryResult { get; set; }
}