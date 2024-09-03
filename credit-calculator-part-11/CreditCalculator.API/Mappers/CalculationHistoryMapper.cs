using CreditCalculator.API.Infrastructure.Entities;
using CreditCalculator.API.Services.CalculationHistory.Models;
using CreditCalculator.API.ViewModels;

namespace CreditCalculator.API.Mappers;

using Core;

internal static class CalculationHistoryMapper
{
    public static CalculationHistoryViewModel MapToViewModel(this CalculationHistory history) =>
        new(
            history.CalcType,
            history.Parameters.MapToViewModel(),
            history.Result.MapToViewModel(),
            history.CreatedOn
        );

    public static CalculationHistoryEntity MapToEntity(this CalculationHistory history)
    {
        return new CalculationHistoryEntity
        {
            CalcType = history.CalcType,
            CalculationHistoryParameters = history.Parameters.MapToEntity(),
            CalculationHistoryResult = history.Result.MapToEntity(),
            CreatedOn = history.CreatedOn
        };
    }

    public static CalculationHistoryParametersEntity MapToEntity(
        this CalculationParameters parameters
    ) =>
        new()
        {
            Credit = parameters.Credit,
            Rate = parameters.Rate,
            Period = parameters.Period
        };

    public static CalculationHistoryResultEntity MapToEntity(
        this CalculationResult result
    )
    {
        return new CalculationHistoryResultEntity
        {
            Payment = result.Payment,
            SumPayment = result.SumPayment,
            SumMainDebtPayment = result.SumMainDebtPayment,
            SumPercentPayment = result.SumPercentPayment,
            MainDebtInPercent = result.MainDebtInPercent,
            PercentsInPercent = result.PercentsInPercent,
            CalculationHistoryPaymentInfos = result.PaymentInfos
                .Select(x => x.MapToEntity()).ToList(),
        };
    }

    public static CalculationHistoryPaymentInfoEntity MapToEntity(this PaymentInfo paymentInfo) =>
        new()
        {
            PaymentNumber = paymentInfo.PaymentNumber,
            Payment = paymentInfo.Payment,
            MainDebtPayment = paymentInfo.MainDebtPayment,
            PercentPayment = paymentInfo.PercentPayment,
            Debt = paymentInfo.Debt
        };
}