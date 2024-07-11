namespace CreditCalculator.Core;

public record CalculationResult(
    double? Payment,
    double SumPayment,
    double SumMainDebtPayment,
    double SumPercentPayment,
    double MainDebtInPercent,
    double PercentsInPercent,
    IReadOnlyCollection<PaymentInfo> PaymentInfos
);