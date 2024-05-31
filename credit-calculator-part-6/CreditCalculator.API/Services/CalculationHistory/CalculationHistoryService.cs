namespace CreditCalculator.API.Services.CalculationHistory;

using Infrastructure;
using Models;

public interface ICalculationHistoryService
{
    IReadOnlyCollection<CalculationHistory> GetCalculationHistory();
    void SaveCalculationHistory(CalculationHistory calculationHistory);
}

internal class CalculationHistoryService(
    ICreditCalculationHistoryRepository calculationHistoryRepository
) : ICalculationHistoryService
{
    public IReadOnlyCollection<CalculationHistory> GetCalculationHistory() =>
        calculationHistoryRepository.GetCalculationHistory();

    public void SaveCalculationHistory(CalculationHistory calculationHistory)
    {
        calculationHistory.CreatedOn = DateTime.Now;
        calculationHistoryRepository.AddHistory(calculationHistory);
    }
}