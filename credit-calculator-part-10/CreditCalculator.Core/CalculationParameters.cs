namespace CreditCalculator.Core;

public record CalculationParameters(
    double Credit,
    double Rate,
    int Period
);