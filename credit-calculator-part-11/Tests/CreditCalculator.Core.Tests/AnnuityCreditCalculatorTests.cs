namespace CreditCalculator.Core.Tests
{
    public class AnnuityCreditCalculatorTests
    {
        ICreditCalculator _calculator;
        [SetUp]
        public void Setup()
        {
            _calculator = new AnnuityCreditCalculator();
        }

        [Test]
        public void Test1()
        {
            var result = _calculator.Calculate(new CalculationParameters(500000, 0.245, 60));
            Assert.Pass();
        }
    }
}