﻿// See https://aka.ms/new-console-template for more information

using System.Text;
using CreditCalculator;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Credit calculator!");

// X = summOfCredit * k
// k коэффициент ануниента
// с сумма кредита
// x ежемесячный платеж
// k = m *(1+m)^s/((1+m)^s -1)
// m - месячная процентная ставка (если кредит под 24 годовых, то m = 2)
// periods - количество пратежей = кол-во месяцев если платим каждый месяц
// 

Console.WriteLine("какая сумма кредита?");

var c = double.Parse(Console.ReadLine()!);

Console.WriteLine("какая процентная ставка?");

var personPeyYear = double.Parse(Console.ReadLine()!) / 100; // преобразуем проценты в нормальную форму

Console.WriteLine("какая месяцев выплаты кредита?");

var periods = int.Parse(Console.ReadLine()!);

var calculator = new CreditCalculator.CreditCalculator();
var (payment, totalPayment, totalPercent, totalPercentsInPercent) = calculator.Calc(new CalculationParameters(c, personPeyYear, periods));



Console.WriteLine($"ежемесячный платеж: {payment:C}");
Console.WriteLine($"всего платежей: {totalPayment:C}");
Console.WriteLine($"начисленные проценты: {totalPercent:C}");
Console.WriteLine($"От общей уплаченой суммы. кол-во переплаченых процентов: {totalPercentsInPercent:0.00}%");


var dept = c;

var paymentNumber = 0;
var sumPayment = 0d;

var sumPercentPayment = 0d;
var sumMainDeptPayment = 0d;
Console.WriteLine($"График платежа");
Console.WriteLine($"№ \t Платеж\t\t тело креда\tпроценты\tостаток долга");
var paymentInfoList = new List<PaymentInfo>();
var m = personPeyYear / 12;
while (dept > 0)
{
    
    paymentNumber++;
    var percentPayment = dept * m;
    var mainDeptPayment = payment - percentPayment;

    if (dept < mainDeptPayment)
    {
        mainDeptPayment = dept;
        percentPayment = 0;
        payment = mainDeptPayment;
    }


    dept -= mainDeptPayment;

    var info = new PaymentInfo(
        paymentNumber,
        payment,
        Math.Round(mainDeptPayment, 2),
        Math.Round(percentPayment, 2),
        Math.Round(dept, 2)
    );
    Console.WriteLine(info);
    paymentInfoList.Add(info);

    sumPayment += payment;
    sumMainDeptPayment += mainDeptPayment;
    sumPercentPayment += percentPayment;
}

Console.WriteLine($"Выплечено всего: {sumPayment:C}");
Console.WriteLine($"Сумма выплначенного долга: {sumMainDeptPayment:C}");
Console.WriteLine($"Сумма выплаченных процетов: {sumPercentPayment:C}");

// псевдографическое представление 
foreach (var info in paymentInfoList)
{
    PrintDeptAndPercent(info.MainDeptPayment, info.PercentPayment);
}
Console.ReadLine();
return;


void PrintDeptAndPercent(double left, double right)
{
    var oldColor = Console.ForegroundColor;
    var total = left + right;
    var countLeft = (int)(left / total * 100);
    var countRight = 100 - countLeft;

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.Write(new string('\\', countLeft));
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(new string('\\', countRight));
    Console.ForegroundColor = oldColor;
}

internal record PaymentInfo(int PaymentNumber, double Payment, double MainDeptPayment, double PercentPayment, double Dept)
{
    public override string ToString() => $"{PaymentNumber}\t {Payment:C}\t {MainDeptPayment:C}\t {PercentPayment:C}\t{Dept:C}";
}