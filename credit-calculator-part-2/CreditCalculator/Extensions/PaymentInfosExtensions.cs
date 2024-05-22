namespace CreditCalculator.Extensions;

internal static class PaymentInfosExtensions
{
    public static void Print(
        this CalculationResult calculationResult
    )
    {
        var (
            payment,
            sumPayment,
            sumMainDebtPayment,
            sumPercentPayment,
            mainDebtInPercent,
            percentsInPercent,
            paymentInfos
            ) = calculationResult;

        Console.WriteLine($"Ежемесячный платёж {payment:C}");
        Console.WriteLine($"Начисленные процены {sumPercentPayment:C}");
        Console.WriteLine($"Долг + проценты {sumPayment:C}");
        Console.WriteLine($"От общей уплаченной суммы: Основной длог={mainDebtInPercent:0.00}%;Проценты={percentsInPercent:0.00}%");

        paymentInfos.Print();

        Console.WriteLine($"Выплачено всего: {sumPayment:C}");
        Console.WriteLine($"Сумма выплаченного долга:{sumMainDebtPayment:C}");
        Console.WriteLine($"Сумма выплаченных процентов:{sumPercentPayment:C}");

        paymentInfos.PrintAsDiagram();
    }

    public static void Print(
        this IReadOnlyCollection<PaymentInfo> paymentInfos
    )
    {
        Console.WriteLine("№\tСумма платежа\tПлатёж по основному долгу\tПлатёж по процентам\tОстаток долга");
        foreach (var paymentInfo in paymentInfos)
        {
            Console.WriteLine($"{paymentInfo.PaymentNumber}\t\t{paymentInfo.Payment:C}\t{paymentInfo.MainDebtPayment:C}\t\t\t{paymentInfo.PercentPayment:C}\t\t\t{paymentInfo.Debt:C}");
        }
    }

    public static void PrintAsDiagram(
        this IReadOnlyCollection<PaymentInfo> paymentInfos
    )
    {
        foreach (var paymentInfo in paymentInfos)
        {
            PrintDebtAndPercents(paymentInfo.MainDebtPayment, paymentInfo.PercentPayment);
        }
    }

    private static void PrintDebtAndPercents(double left, double right)
    {
        var total = left + right;

        var color = Console.ForegroundColor;

        var countLeft = (int)(left / total * 100);
        var countRight = 100 - countLeft;
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(new string('░', countLeft));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(new string('▓', countRight));
        Console.ForegroundColor = color;
    }
}