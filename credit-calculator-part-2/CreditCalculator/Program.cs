using System.Text;
using CreditCalculator;
using CreditCalculator.Extensions;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Credit calculator");

Console.WriteLine("Какая сумма кредита?");
var c = double.Parse(Console.ReadLine()!);
Console.WriteLine("Какая процентная ставка?");
var percentPerYear = double.Parse(Console.ReadLine()!) / 100;
Console.WriteLine("На сколько месяцев берёте креди?");
var s = int.Parse(Console.ReadLine()!);

var calculator = new Calculator();

var calculationResult = calculator.Calculate(new CalculationParameters(
    c,
    percentPerYear,
    s
));

calculationResult.Print();

Console.ReadKey();