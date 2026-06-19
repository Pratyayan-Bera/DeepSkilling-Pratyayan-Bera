using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentValue = 10000;
            double growthRate = 0.10;
            int years = 3;

            double futureValue =
                FinancialForecaster.PredictFutureValue(
                    currentValue,
                    growthRate,
                    years);

            Console.WriteLine($"Future Value after {years} years = {futureValue:F2}");
        }
    }
}