// See https://aka.ms/new-console-template for more information

using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Credit calculator!");

// X = c * k
// k коэффициент ануниента
// с сумма кредита
// x ежемесячный платеж
// k = m *(1+m)^s/((1+m)^s -1)
// m - месячная процентная ставка (если кредит под 24 годовых, то m = 2)
// s - количество пратежей = кол-во месяцев если платим каждый месяц
// 

Console.WriteLine("какая сумма кредита?");

var c = double.Parse(Console.ReadLine()!);

Console.WriteLine("какая процентная ставка?");

var personPeyYear = double.Parse(Console.ReadLine()!) / 100; // преобразуем проценты в нормальную форму

Console.WriteLine("какая месяцев выплаты кредита?");

var s = int.Parse(Console.ReadLine()!);

var m = personPeyYear / 12;
// коэффициент ануниента
var k = m * Math.Pow(1 + m, s) / (Math.Pow(1 + m, s) - 1);
// ежемесячный платеж
var x = c * k;

var payment = x;
var totalPayment = x * s;
var totalPercent = totalPayment - c;

var mainDeptInPercent = (c / totalPayment) * 100;
var percentsInPercent = 100 - mainDeptInPercent;

Console.WriteLine($"ежемесячный платеж: {payment:C}");
Console.WriteLine($"всего платежей: {totalPayment:C}");
Console.WriteLine($"начисленные проценты: {totalPercent:C}");
Console.WriteLine($"От общей уплаченой суммы. основной долг: {mainDeptInPercent:0.00}%; кол-во переплаченых процентов: {percentsInPercent:0.00}%");


var dept = c;

var paymentNumber = 0;
var sumPayment = 0d;

var sumPercentPayment = 0d;
var sumMainDeptPayment = 0d;
Console.WriteLine($"График платежа");
Console.WriteLine($"№ \t Платеж\t\t тело креда\tпроценты\tостаток долга");

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

    var info = new PaymentInfo(paymentNumber, payment, Math.Round(mainDeptPayment, 2), Math.Round(percentPayment, 2), Math.Round(dept, 2));
    Console.WriteLine(info);

    sumPayment += payment;
    sumMainDeptPayment += mainDeptPayment;
    sumPercentPayment += percentPayment;
}

Console.WriteLine($"Выплечено всего: {sumPayment:C}");
Console.WriteLine($"Сумма выплначенного долга: {sumMainDeptPayment:C}");
Console.WriteLine($"Сумма выплаченных процетов: {sumPercentPayment:C}");

Console.ReadLine();

internal record PaymentInfo(int PaymentNumber, double Payment, double MainDeptPayment, double PercentPayment, double Dept)
{
    public override string ToString() => $"{PaymentNumber}\t {Payment:C}\t {MainDeptPayment:C}\t {PercentPayment:C}\t{Dept:C}";
}