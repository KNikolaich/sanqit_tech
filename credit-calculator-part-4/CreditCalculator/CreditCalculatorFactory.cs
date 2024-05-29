namespace CreditCalculator;

internal class CreditCalculatorFactory
{
    public ICreditCalculator CreateCalculator(
        CalcType calcType
    ) =>
        calcType switch
        {
            CalcType.Annuity => new AnnuityCreditCalculator(),
            CalcType.Differentiated => new DifferentiatedCreditCalculator(),
            _ => throw new ArgumentOutOfRangeException()
        };
}