namespace CreditCalculator.API.Controllers;

using Core;
using ViewModels;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using Services.CalculationHistory;
using Services.CalculationHistory.Models;

/// <inheritdoc />
[ApiController]
[Route("credit-calculator")]
public class CreditCalculatorController(
    CreditCalculatorFactory creditCalculatorFactory,
    ICalculationHistoryService calculationHistoryService
) : ControllerBase
{
    /// <summary>
    /// Метод расчёта кредита
    /// </summary>
    /// <param name="calcType">Тип расчёта кредита</param>
    /// <param name="model">Параметры кредита</param>
    /// <returns></returns>
    [HttpPost("{calcType}/calculate", Name = nameof(Calculate))]
    public CalculationResultViewModel Calculate(
        [FromRoute] CalcType calcType,
        [FromBody] CalculationParametersViewModel model
    )
    {
        var calculator = creditCalculatorFactory
            .CreateCalculator(calcType);
        var parameters = model.MapFromViewModel();
        var result = calculator.Calculate(parameters);

        calculationHistoryService.SaveCalculationHistory(new CalculationHistory(
            calcType,
            parameters,
            result
        ));

        return result.MapToViewModel();
    }

    [HttpGet("history", Name = nameof(GetCaluclationHistory))]
    public IReadOnlyCollection<CalculationHistoryViewModel> GetCaluclationHistory()
    {
        var history = calculationHistoryService.GetCalculationHistory();
        return history.Select(x => x.MapToViewModel()).ToList();
    }
}