namespace CreditCalculator.Core;

public interface ICreditCalculator
{
    CalculationResult Calculate(
        CalculationParameters parameters
    );
}