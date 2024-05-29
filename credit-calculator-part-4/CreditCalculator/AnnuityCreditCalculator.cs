namespace CreditCalculator;

internal class AnnuityCreditCalculator : ICreditCalculator
{
    public CalculationResult Calculate(
        CalculationParameters parameters
    )
    {
        var m = parameters.PercentPerYear / 12;
        var k = m * Math.Pow(1 + m, parameters.PeriodsCount) / (Math.Pow(1 + m, parameters.PeriodsCount) - 1);
        var x = parameters.CreditSum * k;

        var payment = x;

        var debt = parameters.CreditSum;

        var paymentNumber = 0;
        var sumPayment = 0d;
        var sumMainDebtPayment = 0d;
        var sumPercentPayment = 0d;

        var paymentForCalculation = payment;
        var paymentInfos = new List<PaymentInfo>();
        while (debt > 0.01)
        {
            paymentNumber++;
            var percentPayment = debt * m;
            var mainDebtPayment = paymentForCalculation - percentPayment;

            if (debt < mainDebtPayment)
            {
                mainDebtPayment = debt;
                percentPayment = 0;
                paymentForCalculation = mainDebtPayment;
            }

            debt -= mainDebtPayment;
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
        
        var mainDebtInPercent = parameters.CreditSum / sumPayment * 100;
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