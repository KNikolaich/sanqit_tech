namespace CreditCalculator.API.Services.CalculationHistory.Models;

using Core;

public record CalculationHistory(
    CalcType CalcType,
    CalculationParameters Parameters,
    CalculationResult Result
)
{
    public DateTime CreatedOn { get; set; }
}