namespace CreditCalculator.API.Infrastructure;

using Core;
using Mappers;
using Microsoft.EntityFrameworkCore;
using Services.CalculationHistory.Models;

public interface ICreditCalculationHistoryRepository
{
    void AddHistory(CalculationHistory calculationHistory);
    IReadOnlyCollection<CalculationHistory> GetCalculationHistory();
}

internal class CreditCalculationHistoryRepository(
    CreditCalculatorDbContext dbContext
) : ICreditCalculationHistoryRepository
{
    public void AddHistory(CalculationHistory calculationHistory)
    {
        dbContext.CalculationHistory.Add(calculationHistory.MapToEntity());
        dbContext.SaveChanges();
    }

    public IReadOnlyCollection<CalculationHistory> GetCalculationHistory()
    {
        var calculationHistoryQueryable = dbContext.CalculationHistory.Select(x => new CalculationHistory(
            x.CalcType,
            new CalculationParameters(
                x.CalculationHistoryParameters.Credit,
                x.CalculationHistoryParameters.Rate,
                x.CalculationHistoryParameters.Period
            ),
            new CalculationResult(
                x.CalculationHistoryResult.Payment,
                x.CalculationHistoryResult.SumPayment,
                x.CalculationHistoryResult.SumMainDebtPayment,
                x.CalculationHistoryResult.SumPercentPayment,
                x.CalculationHistoryResult.MainDebtInPercent,
                x.CalculationHistoryResult.PercentsInPercent,
                x.CalculationHistoryResult.CalculationHistoryPaymentInfos
                    .Select(pi => new PaymentInfo(
                        pi.PaymentNumber,
                        pi.Payment,
                        pi.MainDebtPayment,
                        pi.PercentPayment,
                        pi.Debt))
                    .ToList()
            )
        )
        {
            CreatedOn = x.CreatedOn
        });

        var queryString = calculationHistoryQueryable.ToQueryString();
        return calculationHistoryQueryable.ToList();
    }
}