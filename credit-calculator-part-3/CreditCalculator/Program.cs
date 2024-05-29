using System.Text;
using CreditCalculator;
using CreditCalculator.Extensions;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Credit calculator");

Console.WriteLine("Какая сумма кредита?");
var c = double.Parse(Console.ReadLine()!);
Console.WriteLine("Какая процентная ставка?");
var percentPerYear = double.Parse(Console.ReadLine()!) / 100;
Console.WriteLine("На сколько месяцев берёте кредит?");
var s = int.Parse(Console.ReadLine()!);


CalcType kindOfCalc;
do
{
    Console.WriteLine($"Какой тип расчета использовать. {CalcType.Annuity}({(int)CalcType.Annuity}) или {CalcType.Differentiated}({(int)CalcType.Differentiated})");
} while (!Enum.TryParse(Console.ReadLine()!, out kindOfCalc) || (kindOfCalc != CalcType.Annuity && kindOfCalc != CalcType.Differentiated));

ICreditCalculator calculator = kindOfCalc switch
{
    CalcType.Annuity => new AnnuityCalculator(),
    CalcType.Differentiated => new DifferentiatedCalculator()
};

var calculationResult = calculator.Calculate(new CalculationParameters(
    c,
    percentPerYear,
    s
));

Console.WriteLine(kindOfCalc switch
    {
        CalcType.Annuity => "Аннуентный платеж",
        CalcType.Differentiated => "Диффиренцированный платеж"
    });
;
calculationResult.Print();

Console.ReadKey();