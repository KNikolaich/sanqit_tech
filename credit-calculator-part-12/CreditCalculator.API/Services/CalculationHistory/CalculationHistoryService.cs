namespace CreditCalculator.API.Services.CalculationHistory;

using Configuration;
using Infrastructure;
using Microsoft.Extensions.Options;
using Models;

public interface ICalculationHistoryService
{
    IReadOnlyCollection<CalculationHistory> GetCalculationHistory();
    void SaveCalculationHistory(CalculationHistory calculationHistory);
}

internal class CalculationHistoryService(
    ICreditCalculationHistoryRepository calculationHistoryRepository,
    IOptionsMonitor<ServiceOptions> optionsMonitor
) : ICalculationHistoryService
{
    public IReadOnlyCollection<CalculationHistory> GetCalculationHistory() =>
        optionsMonitor.CurrentValue.DisableCalculationHistory
            ? []
            : calculationHistoryRepository.GetCalculationHistory();

    public void SaveCalculationHistory(CalculationHistory calculationHistory)
    {
        if (optionsMonitor.CurrentValue.DisableCalculationHistory)
        {
            return;
        }

        calculationHistory.CreatedOn = DateTime.UtcNow;
        calculationHistoryRepository.AddHistory(calculationHistory);
    }
}