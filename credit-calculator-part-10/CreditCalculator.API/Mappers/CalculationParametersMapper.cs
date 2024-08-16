namespace CreditCalculator.API.Mappers;

using Core;
using ViewModels;

internal static class CalculationParametersMapper
{
    public static CalculationParameters MapFromViewModel(
        this CalculationParametersViewModel model
    ) =>
        new(model.Credit, model.Rate / 100, model.Period);

    public static CalculationParametersViewModel MapToViewModel(
        this CalculationParameters parameters
    ) =>
        new(parameters.Credit, parameters.Rate, parameters.Period);

    public static CalculationResultViewModel MapToViewModel(
        this CalculationResult result
    )
    {
        return new CalculationResultViewModel(
            result.Payment,
            result.SumPayment,
            result.SumMainDebtPayment,
            result.SumPercentPayment,
            result.MainDebtInPercent,
            result.PercentsInPercent,
            result.PaymentInfos.Select(x => x.MapToViewModel()).ToList()
        );
    }

    public static PaymentInfoViewModel MapToViewModel(
        this PaymentInfo paymentInfo
    ) =>
        new(
            paymentInfo.PaymentNumber,
            paymentInfo.Payment,
            paymentInfo.MainDebtPayment,
            paymentInfo.PercentPayment,
            paymentInfo.Debt
        );
}