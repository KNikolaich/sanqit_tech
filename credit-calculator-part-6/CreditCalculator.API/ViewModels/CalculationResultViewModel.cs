namespace CreditCalculator.API.ViewModels;

/// <summary>
/// Результат расчёта кредита
/// </summary>
/// <param name="Payment"></param>
/// <param name="SumPayment"></param>
/// <param name="SumMainDebtPayment"></param>
/// <param name="SumPercentPayment"></param>
/// <param name="MainDebtInPercent"></param>
/// <param name="PercentsInPercent"></param>
/// <param name="PaymentInfos"></param>
public record CalculationResultViewModel(
    double? Payment,
    double SumPayment,
    double SumMainDebtPayment,
    double SumPercentPayment,
    double MainDebtInPercent,
    double PercentsInPercent,
    IReadOnlyCollection<PaymentInfoViewModel> PaymentInfos
);