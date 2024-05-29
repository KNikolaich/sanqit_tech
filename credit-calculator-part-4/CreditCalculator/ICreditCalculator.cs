namespace CreditCalculator;

internal interface ICreditCalculator
{
    CalculationResult Calculate(
        CalculationParameters parameters
    );
}