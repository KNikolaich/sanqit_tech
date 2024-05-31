namespace CreditCalculator.API.Controllers;

using Core;
using ViewModels;
using Mappers;
using Microsoft.AspNetCore.Mvc;

/// <inheritdoc />
[ApiController]
[Route("credit-calculator")]
public class CreditCalculatorController(
    CreditCalculatorFactory creditCalculatorFactory
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
        return result.MapToViewModel();
    }
}