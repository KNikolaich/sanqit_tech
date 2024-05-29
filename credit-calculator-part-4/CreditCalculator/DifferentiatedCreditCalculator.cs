namespace CreditCalculator;

internal class DifferentiatedCreditCalculator : ICreditCalculator
{
    public CalculationResult Calculate(
        CalculationParameters parameters
    )
    {
        //https://finuslugi.ru/glossariy/raschyot_differencirovannogo_platezha
        var m = parameters.PercentPerYear / 12;
        var mainDebtPayment = parameters.CreditSum / parameters.PeriodsCount;

        var debt = parameters.CreditSum;

        var paymentNumber = 0;
        var sumPayment = 0d;
        var sumMainDebtPayment = 0d;
        var sumPercentPayment = 0d;

        var paymentInfos = new List<PaymentInfo>();
        while (debt >= 0.01)
        {
            paymentNumber++;
            var percentPayment = debt * m;

            var paymentForCalculation = percentPayment + mainDebtPayment;

            debt -= mainDebtPayment;
            var paymentInfo = new PaymentInfo(
                paymentNumber,
                paymentForCalculation,
                mainDebtPayment,
                percentPayment,
                debt
            );

            paymentInfos.Add(paymentInfo);

            sumPayment += paymentForCalculation;
            sumMainDebtPayment += mainDebtPayment;
            sumPercentPayment += percentPayment;
        }

        var mainDebtInPercent = parameters.CreditSum / sumPayment * 100;
        var percentsInPercent = 100 - mainDebtInPercent;

        return new CalculationResult(
            null,
            sumPayment,
            sumMainDebtPayment,
            sumPercentPayment,
            mainDebtInPercent,
            percentsInPercent,
            paymentInfos
        );
    }
}