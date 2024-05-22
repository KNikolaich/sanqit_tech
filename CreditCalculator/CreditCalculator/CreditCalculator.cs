namespace CreditCalculator;

internal class CreditCalculator
{
    public CalculationResult Calc(
        CalculationParameters parameters)
    {

        var m = parameters.personPeyYear / 12;
        // коэффициент ануниента
        var k = m * Math.Pow(1 + m, parameters.periods) / (Math.Pow(1 + m, parameters.periods) - 1);
        // ежемесячный платеж
        var x = parameters.summOfCredit * k;

        var payment = x;
        var totalPayment = x * parameters.periods;
        var totalPercent = totalPayment - parameters.summOfCredit;

        var mainDeptInPercent = (parameters.summOfCredit / totalPayment) * 100;
        var percentsInPercent = 100 - mainDeptInPercent;
        return new CalculationResult(payment, totalPayment, totalPercent, percentsInPercent);
    }
}

internal record CalculationParameters(double summOfCredit, double personPeyYear, int periods);

internal record CalculationResult(double payment, double totalPayment, double totalPercent, double percentsInPercent);