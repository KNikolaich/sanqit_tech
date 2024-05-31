namespace CreditCalculator.API.ViewModels;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Параметры кредита
/// </summary>
/// <param name="Credit">Кредит</param>
/// <param name="Rate">Процентная ставка</param>
/// <param name="Period">На какой срок</param>
public record CalculationParametersViewModel(
    [Range(1, double.MaxValue, ErrorMessage = "Сумма кредита должна быть больше 0")]
    double Credit,
    [Range(double.Epsilon, 100, ErrorMessage = "Процентная ставка должна быть больше 0 и не больше 100")]
    double Rate,
    [Range(1, int.MaxValue, ErrorMessage = "Период должен быть больше 0")]
    int Period
);