namespace CreditCalculator.Extensions;

internal static class DictionaryExtensions
{
    public static void Print<TKey, TValue>(this IDictionary<TKey, TValue> dict)
    {
        foreach (var kvp in dict)
        {
            Console.WriteLine($"{kvp.Key} is {kvp.Value}");
        }
    }
}