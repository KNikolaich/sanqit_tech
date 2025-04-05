namespace CreditCalculator.API.ViewModels;

using Core;

/// <summary>
/// История расчётов
/// </summary>
/// <param name="CalcType">Тип расчета</param>
/// <param name="Parameters">Параметры расчета</param>
/// <param name="CalculationResult">Результат расчета</param>
/// <param name="CreatedOn">Дата расчета</param>
public record CalculationHistoryViewModel(
    CalcType CalcType,
    CalculationParametersViewModel Parameters,
    CalculationResultViewModel CalculationResult,
    DateTime CreatedOn
);