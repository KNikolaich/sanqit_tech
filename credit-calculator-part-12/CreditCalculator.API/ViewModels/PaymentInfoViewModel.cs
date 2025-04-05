namespace CreditCalculator.API.ViewModels;

/// <summary>
/// Информация о платеже
/// </summary>
/// <param name="PaymentNumber">Номер платежа</param>
/// <param name="Payment">Платёж</param>
/// <param name="MainDebtPayment">Платёж по основному долгу</param>
/// <param name="PercentPayment">Платёж по процентам</param>
/// <param name="Debt">Остаток долга</param>
public record PaymentInfoViewModel(
    int PaymentNumber,
    double Payment,
    double MainDebtPayment,
    double PercentPayment,
    double Debt
);