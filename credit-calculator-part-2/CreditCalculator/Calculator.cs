namespace CreditCalculator;

internal class Calculator
{
    public CalculationResult Calculate(
        CalculationParameters parameters
    )
    {
        var m = parameters.PercentPerYear / 12;
        var k = m * Math.Pow(1 + m, parameters.PeriodsCount) / (Math.Pow(1 + m, parameters.PeriodsCount) - 1);
        var x = parameters.CreditSum * k;

        var payment = Math.Round(x, 2);

        var debt = parameters.CreditSum;

        var paymentNumber = 0;
        var sumPayment = 0d;
        var sumMainDebtPayment = 0d;
        var sumPercentPayment = 0d;

        var paymentForCalculation = payment;
        var paymentInfos = new List<PaymentInfo>();
        while (debt > 0)
        {
            paymentNumber++;
            var percentPayment = Math.Round(debt * m, 2);
            var mainDebtPayment = Math.Round(paymentForCalculation - percentPayment, 2);

            if (debt < mainDebtPayment)
            {
                mainDebtPayment = debt;
                percentPayment = 0;
                paymentForCalculation = mainDebtPayment;
            }

            debt = Math.Round(debt - mainDebtPayment, 2);
            var paymentInfo = new PaymentInfo(
                paymentNumber,
                paymentForCalculation,
                mainDebtPayment,
                percentPayment,
                debt);
            paymentInfos.Add(paymentInfo);

            sumPayment += paymentForCalculation;
            sumMainDebtPayment += mainDebtPayment;
            sumPercentPayment += percentPayment;
        }
        
        var mainDebtInPercent = Math.Round(parameters.CreditSum / sumPayment, 2) * 100;
        var percentsInPercent = 100 - mainDebtInPercent;

        return new CalculationResult(
            payment,
            sumPayment,
            sumMainDebtPayment,
            sumPercentPayment,
            mainDebtInPercent,
            percentsInPercent,
            paymentInfos
        );
    }
}