namespace CreditCalculator;

internal class DifferentiatedCalculator : ICreditCalculator
{
    public CalculationResult Calculate(CalculationParameters parameters)
    {
        var m = parameters.PercentPerYear / 12;

        var mainDebtPayment = parameters.CreditSum / parameters.PeriodsCount;

        var debt = parameters.CreditSum;

        var paymentNumber = 0;
        var sumPayment = 0d;
        var sumMainDebtPayment = 0d;
        var sumPercentPayment = 0d;
        var paymentInfos = new List<PaymentInfo>();
        
        while (debt > 0)
        {
            paymentNumber++;
            var percentPayment = debt * m;
            var paymentForCalculation = percentPayment + mainDebtPayment;

            debt -= mainDebtPayment;

            paymentInfos.Add(new PaymentInfo(
                paymentNumber, 
                paymentForCalculation,
                mainDebtPayment, 
                percentPayment, 
                debt));


            sumPayment += paymentForCalculation;
            sumMainDebtPayment += mainDebtPayment;
            sumPercentPayment += percentPayment;

        }


        double mainDebtInPercent = parameters.CreditSum / sumPayment * 100;
        return new CalculationResult(
            null,
            sumPayment,
            sumMainDebtPayment,
            sumPercentPayment,
            mainDebtInPercent,
            100 - mainDebtInPercent,
            paymentInfos);
    }
}