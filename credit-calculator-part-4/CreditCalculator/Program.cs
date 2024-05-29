using System.Text;
using CreditCalculator;
using CreditCalculator.Extensions;

Console.OutputEncoding = Encoding.UTF8;

var inputContext = new Dictionary<InputKey, object>
{
    { InputKey.Credit , 0d },
    { InputKey.Rate, 0d },
    { InputKey.Period , 0 },
    { InputKey.CalcType, CalcType.Annuity }
};

inputContext.Print();

var creditCalculatorFactory = new CreditCalculatorFactory();
while (true)
{
    var val = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    var command = val[0];
    var input = new ArraySegment<string>(val, 1, val.Length - 1).ToArray();
    Console.Clear();
    if (command == "exit")
    {
        break;
    }

    switch (command)
    {
        case "reset":
        {
            inputContext[InputKey.Credit] = 0d;
            inputContext[InputKey.Rate] = 0d;
            inputContext[InputKey.Period] = 0;
            inputContext[InputKey.CalcType] = CalcType.Annuity;
            inputContext.Print();
            break;
        }
        case "print":
        {
            if (input.Length == 1)
            {
                switch (input[0])
                {
                    case "input":
                    {
                        inputContext.Print();
                        break;
                    }
                    case "result":
                    {
                        if (TryExtractParameters(inputContext, out var calculationParameters, out var errors))
                        {
                            var calculator = creditCalculatorFactory
                                    .CreateCalculator((CalcType)inputContext[InputKey.CalcType]);
                            var calculationResult = calculator.Calculate(calculationParameters);
                            Console.WriteLine();
                            calculationResult.Print();
                        }
                        else
                        {
                            foreach (var error in errors)
                            {
                                Console.WriteLine(error);
                            }
                        }

                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Не верный параметр");
                        break;
                    }
                }
            }
            else
            {
                inputContext.Print();
            }

            break;
        }
        case "set":
        {
            if (!Enum.TryParse<InputKey>(input[0], true, out var inputKey))
            {
                Console.WriteLine("Не корректное имя переменной в контексте");
                continue;
            }

            switch (inputKey)
            {
                case InputKey.Credit:
                case InputKey.Rate:
                {
                    if (double.TryParse(input[1], out var value))
                    {
                        inputContext[inputKey] = value;
                    }
                    else
                    {
                        Console.WriteLine($"Значение {inputKey} не корректно");
                    }
                    break;
                }
                case InputKey.Period:
                {
                    if(int.TryParse(input[1], out var value))
                    {
                        inputContext[inputKey] = value;
                    }
                    else
                    {
                        Console.WriteLine($"Значение {inputKey} не корректно");
                    }
                    break;
                }
                case InputKey.CalcType:
                {
                    if(Enum.TryParse<CalcType>(input[1], true, out var calcType))
                    {
                        inputContext[inputKey] = calcType;
                    }
                    else
                    {
                        Console.WriteLine($"Значение {inputKey} не корректно");
                    }
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            inputContext.Print();
            break;
        }
    }
}

return;

bool TryExtractParameters(
    IDictionary<InputKey, object> dict,
    out CalculationParameters calculationParameters,
    out List<string> errors
)
{
    errors = [];

    var creditSum = (double)dict[InputKey.Credit];
    var rate = (double)dict[InputKey.Rate] / 100;
    var period = (int)dict[InputKey.Period];

    if (creditSum <= 0)
    {
        errors.Add("Сумма кредита должна быть больше 0");
    }

    if (rate <= 0)
    {
        errors.Add("Процентная ставка должна быть больше 0");
    }

    if (period < 1)
    {
        errors.Add("Период должен быть больше 0");
    }

    calculationParameters = new CalculationParameters(creditSum, rate, period);
    return errors.Count == 0;
}

internal enum InputKey
{
    Credit,
    Rate,
    Period,
    CalcType
}