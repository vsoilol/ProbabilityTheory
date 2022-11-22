using System;
using System.Linq;
using IndividualTask2.Models;

namespace IndividualTask2
{
    public class ConsolePresenter
    {
        private readonly DocumentService _documentService;
        
        public ConsolePresenter(DocumentService documentService)
        {
            _documentService = documentService;
        }
        
        public int[] GetNumbers()
        {
            Console.Write("Enter i: ");
            var i = int.Parse(Console.ReadLine());

            Console.Write("Enter n: ");
            var n = int.Parse(Console.ReadLine());

            return _documentService.GetNumbersFromFile(i, n);
        }
        
        public int[] GetNumbers(int i, int n)
        {
            return _documentService.GetNumbersFromFile(i, n);
        }

        public void DisplayAllCalculation(MathData mathData)
        {
            DisplayTask_1_a(mathData);
            DisplayTask_1_b(mathData);
            DisplaySampleAverage(mathData.SampleAverage);
            DisplaySampleVariance(mathData.SampleVariance);
            DisplaySampleMeanSquareDeviation(mathData.SampleMeanSquareDeviation);
            DisplayCorrectedSampleVariance(mathData.CorrectedSampleVariance);
            DisplayCorrectedSampleMeanSquareDeviation(mathData.CorrectedSampleMeanSquareDeviation);
            DisplayVariationScope(mathData.VariationScope);
            DisplayMode(mathData.Mode);
            DisplayMedian(mathData.Median);
        }
        
        private void DisplayTask_1_a(MathData mathData)
        {
            var result = "";
            result += string.Join("\n",
                mathData.Values.Select(_ => $"Number {_.Value}, Count {_.Count}, Freq {_.Frequency}"));
            result += $"\nCount: {mathData.Values.Sum(_ => _.Count)}";
            result += $"\nFreq sum: {mathData.Values.Sum(_ => _.Frequency)}";

            Console.WriteLine(result);
        }
        
        private void DisplayTask_1_b(MathData mathData)
        {
            var result = $"\nFunction:\n";
            result += "Значение: 0, при x <= 0\n";
            result += string.Join("\n", mathData.EmpiricalFunctionValues.Select(_ => _.ToString()));
            result += $"\nЗначение: 1, при x > {mathData.Values.Last().Value}\n";

            Console.WriteLine(result);
        }

        private void DisplaySampleAverage(decimal sampleAverage)
        {
            Console.WriteLine($"Выборочное среднее: {sampleAverage}");
        }
        
        private void DisplaySampleVariance(decimal sampleVariance)
        {
            Console.WriteLine($"Выборочная дисперсия: {sampleVariance}");
        }

        private void DisplaySampleMeanSquareDeviation(decimal sampleMeanSquareDeviation)
        {
            Console.WriteLine($"Выборочное среднее квадратическое отклонение: {sampleMeanSquareDeviation}");
        }

        private void DisplayCorrectedSampleVariance(decimal correctedSampleVariance)
        {
            Console.WriteLine($"Исправленная выборочная дисперсия: {correctedSampleVariance}");
        }

        private void DisplayCorrectedSampleMeanSquareDeviation(decimal correctedSampleMeanSquareDeviation)
        {
            Console.WriteLine($"Исправленное выборочное среднее квадратическое отклонение: {correctedSampleMeanSquareDeviation}");
        }

        private void DisplayVariationScope(int variationScope)
        {
            Console.WriteLine($"Размах вариации: {variationScope}");
        }

        private void DisplayMode(decimal mode)
        {
            Console.WriteLine($"Мода: {mode}");
        }

        private void DisplayMedian(decimal median)
        {
            Console.WriteLine($"Медиана: {median}");
        }
    }
}