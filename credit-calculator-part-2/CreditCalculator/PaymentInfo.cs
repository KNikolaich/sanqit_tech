namespace CreditCalculator;

internal record PaymentInfo(
    int PaymentNumber,
    double Payment,
    double MainDebtPayment,
    double PercentPayment,
    double Debt
);